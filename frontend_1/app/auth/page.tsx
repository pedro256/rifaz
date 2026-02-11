'use client';
import { Button } from "@/components/ui/button";
import { Field, FieldError, FieldGroup, FieldLabel } from "@/components/ui/field";
import { Input } from "@/components/ui/input";
import { SignInFormSchema, SignInFormType } from "@/app/auth/validators/SignInFormValidator";
import { zodResolver } from "@hookform/resolvers/zod";
import Link from "next/link";
import { useForm } from "react-hook-form";

export default function AuthPage() {
  // document.documentElement.setAttribute("data-theme", "dark")

  const { register,handleSubmit,formState:{errors}} = useForm<SignInFormType>({
    resolver: zodResolver(SignInFormSchema)
  })

  const onSubmit = (data:any) => {
    console.log(data)
  }

  return (
    <main className="flex justify-center items-center h-screen">
      <div className="w-full border px-8 py-10 min-w-[40%] max-w-[90%] md:max-w-[40%] rounded">
        <div>
          <h1 className="text-3xl">Entrar</h1>
          <p className="opacity-70">
            Caso você tenha acesso ao sistema e queira verificar as suas rifas
            ou criar novas acesse aqui.
          </p>
        </div>
        <form onSubmit={handleSubmit(onSubmit)} className="bg-chart-2">
          <FieldGroup className="mt-6">
            <Field>
              <FieldLabel>Usuário:</FieldLabel>
              <Input title="username" {...register("username")} isInvalid={errors.username!=undefined} required/>
              {errors.username && <FieldError>{errors.username.message}</FieldError>}
            </Field>
            <Field>
              <FieldLabel>Senha:</FieldLabel>
              <Input title="password" {...register("password")} isInvalid={errors.password!=undefined} required/>
              {errors.password && <FieldError>{errors.password.message}</FieldError>}
            </Field>
            <Button type="submit" variant="outline">OK</Button>
          </FieldGroup>
        </form>
        <div className="mt-8 opacity-70 hover:opacity-100">
          <span>Ainda não tem cadastro? <Link href="/register">Cadastre-se aqui</Link></span>
        </div>
      </div>
    </main>
  );
}
