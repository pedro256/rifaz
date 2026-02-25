'use client';
import { Button } from "@/components/ui/button";
import { Field, FieldError, FieldGroup, FieldLabel } from "@/components/ui/field";
import { Input } from "@/components/ui/input";
import { SignInFormSchema, SignInFormType } from "@/app/auth/validators/SignInFormValidator";
import { zodResolver } from "@hookform/resolvers/zod";
import Link from "next/link";
import { useForm } from "react-hook-form";
import { LogIn, KeyRound, User, ArrowRight } from "lucide-react";

export default function AuthPage() {
  const { 
    register, 
    handleSubmit, 
    formState: { errors, isSubmitting } 
  } = useForm<SignInFormType>({
    resolver: zodResolver(SignInFormSchema)
  })

  const onSubmit = (data: any) => {
    console.log(data)
  }

  return (
    <main className="min-h-screen bg-background flex items-center justify-center p-4">
      {/* Container Principal com a paleta OKLCH */}
      <div className="w-full max-w-[440px] bg-card border border-border rounded-radius shadow-2xl shadow-black/[0.03] overflow-hidden">
        
        {/* Header de Boas-vindas */}
        <div className="px-8 pt-12 pb-6 text-center">
          <div className="inline-flex items-center justify-center bg-primary p-3 rounded-2xl mb-6 shadow-lg shadow-primary/10">
            <LogIn className="text-primary-foreground w-6 h-6" />
          </div>
          <h1 className="text-3xl font-bold tracking-tighter text-foreground mb-3">
            Bem-vindo de volta
          </h1>
          <p className="text-muted-foreground text-sm leading-relaxed px-4">
            Acesse sua conta para gerenciar seus sorteios e acompanhar suas vendas em tempo real.
          </p>
        </div>

        {/* Formulário */}
        <div className="px-8 pb-10">
          <form onSubmit={handleSubmit(onSubmit)} className="space-y-5">
            <FieldGroup className="flex flex-col gap-5">
              
              {/* Campo de Usuário */}
              <Field className="flex flex-col gap-2">
                <FieldLabel className="text-[10px] uppercase tracking-[0.15em] font-black text-muted-foreground ml-1">
                  Usuário ou Email
                </FieldLabel>
                <div className="relative group">
                  <User className="absolute left-3 top-1/2 -translate-y-1/2 w-4 h-4 text-muted-foreground group-focus-within:text-foreground transition-colors" />
                  <Input 
                    {...register("username")} 
                    className="pl-10 bg-background border-input focus:ring-ring h-11"
                    placeholder="Seu nome de usuário"
                  />
                </div>
                {errors.username && <FieldError className="text-destructive text-xs italic">{errors.username.message}</FieldError>}
              </Field>

              {/* Campo de Senha */}
              <Field className="flex flex-col gap-2">
                <div className="flex justify-between items-end ml-1">
                  <FieldLabel className="text-[10px] uppercase tracking-[0.15em] font-black text-muted-foreground">
                    Senha
                  </FieldLabel>
                  <Link href="#" className="text-[10px] font-bold text-muted-foreground hover:text-foreground transition-colors uppercase">
                    Esqueceu?
                  </Link>
                </div>
                <div className="relative group">
                  <KeyRound className="absolute left-3 top-1/2 -translate-y-1/2 w-4 h-4 text-muted-foreground group-focus-within:text-foreground transition-colors" />
                  <Input 
                    type="password"
                    {...register("password")} 
                    className="pl-10 bg-background border-input focus:ring-ring h-11"
                    placeholder="••••••••"
                  />
                </div>
                {errors.password && <FieldError className="text-destructive text-xs italic">{errors.password.message}</FieldError>}
              </Field>

              {/* Botão de Ação Principal */}
              <Button 
                type="submit" 
                disabled={isSubmitting}
                className="w-full h-12 bg-primary text-primary-foreground rounded-radius font-bold text-sm flex items-center justify-center gap-2 hover:opacity-90 transition-all active:scale-[0.98] mt-2 shadow-lg shadow-primary/5"
              >
                {isSubmitting ? "Autenticando..." : "Entrar no Painel"}
                <ArrowRight size={18} />
              </Button>
            </FieldGroup>
          </form>
        </div>

        {/* Footer com link de registro */}
        <div className="bg-muted/30 border-t border-border py-6 text-center">
          <span className="text-sm text-muted-foreground">
            Novo por aqui?{' '}
            <Link 
              href="/register" 
              className="text-link font-bold hover:underline decoration-primary underline-offset-4"
            >
              Criar uma conta gratuita
            </Link>
          </span>
        </div>
      </div>
    </main>
  );
}