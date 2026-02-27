import NextAuth, { NextAuthOptions } from "next-auth";
import CredentialsProvider from "next-auth/providers/credentials";
import type { JWT } from "next-auth/jwt";
import { jwtDecode, JwtPayload } from "jwt-decode";
import { OAuthConfig } from "next-auth/providers/oauth";

interface KeycloakTokenResponse {
  access_token: string;
  expires_in: number;
  refresh_token: string;
  refresh_expires_in: number;
  token_type: string;
  id_token: string;
  "not-before-policy": number;
  session_state: string;
  scope: string;
}

interface TokenPayload extends JwtPayload {
  preferred_username: string;
}

async function refreshAccessToken(token: JWT): Promise<JWT> {
  try {
    const url = `${process.env.KEYCLOAK_ISSUER}/protocol/openid-connect/token`;

    const params = new URLSearchParams({
      grant_type: "refresh_token",
      client_id: process.env.KEYCLOAK_CLIENT_ID!,
      client_secret: process.env.KEYCLOAK_CLIENT_SECRET!,
      refresh_token: token.refreshToken as string,
    });

    const response = await fetch(url, {
      method: "POST",
      headers: {
        "Content-Type": "application/x-www-form-urlencoded",
      },
      body: params,
    });

    const refreshedTokens: KeycloakTokenResponse = await response.json();

    if (!response.ok) {
      throw refreshedTokens;
    }

    return {
      ...token,
      accessToken: refreshedTokens.access_token,
      accessTokenExpires: Date.now() + refreshedTokens.expires_in * 1000,
      refreshToken:
        refreshedTokens.refresh_token ?? (token.refreshToken as string),
    };
  } catch (error) {
    console.error("Erro ao atualizar token:", error);

    return {
      ...token,
      error: "RefreshAccessTokenError",
    };
  }
}

export const authOptions: NextAuthOptions = {
  providers: [
    CredentialsProvider({
      name: "Credentials",
      id: "application",
      credentials: {
        username: { label: "Usuário", type: "text" },
        password: { label: "Senha", type: "password" },
      },
      async authorize(credentials) {
        if (!credentials) {
          throw new Error("Credenciais inválidas");
        }
        const url = `${process.env.KEYCLOAK_ISSUER}/protocol/openid-connect/token`;

        const params = new URLSearchParams({
          grant_type: "password",
          client_id: process.env.KEYCLOAK_CLIENT_ID!,
          client_secret: process.env.KEYCLOAK_CLIENT_SECRET!,
          username: credentials.username,
          password: credentials.password,
        });

        const response = await fetch(url, {
          method: "POST",
          headers: {
            "Content-Type": "application/x-www-form-urlencoded",
          },
          body: params,
        });

        const tokens: KeycloakTokenResponse = await response.json();
        const decoded = jwtDecode<TokenPayload>(tokens.access_token);
        console.log('tk: '+tokens.access_token)

        if (!response.ok) {
          console.error("autenticacao erro", tokens);
          throw new Error("Credenciais inválidas");
        }

        return {
          id: credentials.username,
          name: decoded.preferred_username,
          accessToken: tokens.access_token,
          refreshToken: tokens.refresh_token,
          expiresIn: tokens.expires_in,
          idToken: ""
        };
      },
    }),
  ],

  session: {
    strategy: "jwt",
  },

  callbacks: {
    async jwt({ token, user }) {
      // Primeiro login
      if (user) {
        token.accessToken = (user as any).accessToken;
        token.refreshToken = (user as any).refreshToken;
        token.accessTokenExpires = Date.now() + (user as any).expiresIn * 1000;
        token.idToken = (user as any).idToken
        return token;
      }

      // Token ainda válido
      if (Date.now() < (token.accessTokenExpires as number)) {
        return token;
      }

      // Token expirado → refresh
      return refreshAccessToken(token);
      //sem refresh token:
      //return {};
    },

    async session({ session, token }) {
      session.accessToken = token.accessToken as string;
      session.error = token.error as string | undefined;
      return session;
    },
  },
  events: {
    async signOut({ token }: { token: JWT }) {
      if (token.providerId ==='application') {
        try {

          const logOutUrl = new URL(
            `${process.env.KEYCLOAK_ISSUER}/protocol/openid-connect/logout`,
          );
          logOutUrl.searchParams.set("id_token_hint", token.idToken!);
          await fetch(logOutUrl);
        } catch (e) {
          console.error("erro ao deslogar kc: ", e);
        }
      }
    },
  },

  secret: process.env.NEXTAUTH_SECRET,

  pages: {
    signIn: "/auth",
    error: "/auth",
  },

  debug: true,
};

const handler = NextAuth(authOptions);

export { handler as GET, handler as POST };
