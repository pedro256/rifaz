'use client';
import { Field, FieldError, FieldLabel } from "@/components/ui/field";
import { Input } from "@/components/ui/input";
import { useForm } from "react-hook-form";
import { UserRegisterFormSchema, UserRegisterFormType } from "./validators/UserRegisterValidator";
import { zodResolver } from "@hookform/resolvers/zod";
import { Button } from "@/components/ui/button";
import { registerUserAction } from "./actions";
import { useDialog } from "@/components/dialog/dialog-provider";
import { useRouter } from "next/navigation";
import { toast } from "sonner";
import { ArrowRight, UserPlus, ShieldCheck } from "lucide-react"; // Ícones para dar vida

export default function RegisterPage() {
  const {
    register,
    formState: { errors, isSubmitting },
    handleSubmit
  } = useForm<UserRegisterFormType>({
    resolver: zodResolver(UserRegisterFormSchema)
  })

  const dialog = useDialog()
  const route = useRouter()

  async function onSubmit(data: UserRegisterFormType) {
    const formData = new FormData();
    Object.entries(data).forEach(([key, value]) => {
      formData.append(key, value as string);
    });
    
    try {
      await registerUserAction(formData);
      toast.success("Conta criada com sucesso!", { position: "top-center" });
      route.push("/auth");
    } catch (e: any) {
      dialog.error({
        title: "Erro ao Cadastrar",
        description: e.message
      });
    }
  }

  return (
    <main className="min-h-screen bg-background flex items-center justify-center p-6">
      {/* Container Principal com largura máxima controlada para não "espichar" em telas grandes */}
      <div className="w-full max-w-2xl bg-card border border-border rounded-radius shadow-xl shadow-black/[0.02] overflow-hidden">
        
        {/* Header do Card com gradiente sutil */}
        <div className="px-8 pt-10 pb-6 border-b border-border bg-gradient-to-b from-muted/30 to-transparent">
          <div className="flex items-center gap-3 mb-2">
            <div className="bg-primary p-2 rounded-lg">
              <UserPlus className="text-primary-foreground w-5 h-5" />
            </div>
            <h2 className="text-2xl font-bold tracking-tight text-foreground">
              Crie sua conta
            </h2>
          </div>
          <p className="text-muted-foreground text-sm leading-relaxed">
            Junte-se a milhares de organizadores. Comece a criar suas rifas profissionais hoje mesmo.
          </p>
        </div>

        <div className="p-8">
          <form onSubmit={handleSubmit(onSubmit)} className="space-y-6">
            <div className="grid grid-cols-1 md:grid-cols-2 gap-x-6 gap-y-4">
              
              {/* Nome Completo - Ocupa 2 colunas no mobile, 1 no desktop */}
              <Field className="flex flex-col gap-1.5">
                <FieldLabel className="text-xs uppercase tracking-widest font-bold opacity-70">Nome Completo</FieldLabel>
                <Input 
                  {...register("fullname")} 
                  placeholder="Ex: João Silva"
                  className="bg-background border-input focus:ring-ring"
                />
                {errors.fullname && <FieldError className="text-destructive text-xs">{errors.fullname.message}</FieldError>}
              </Field>

              {/* Email */}
              <Field className="flex flex-col gap-1.5">
                <FieldLabel className="text-xs uppercase tracking-widest font-bold opacity-70">Email</FieldLabel>
                <Input 
                  type="email" 
                  {...register("email")} 
                  placeholder="voce@seuemail.com"
                  className="bg-background border-input focus:ring-ring"
                />
                {errors.email && <FieldError className="text-destructive text-xs">{errors.email.message}</FieldError>}
              </Field>

              {/* Senha */}
              <Field className="flex flex-col gap-1.5">
                <FieldLabel className="text-xs uppercase tracking-widest font-bold opacity-70">Senha</FieldLabel>
                <Input 
                  type="password" 
                  {...register("password")} 
                  placeholder="••••••••"
                  className="bg-background border-input focus:ring-ring"
                />
                {errors.password && <FieldError className="text-destructive text-xs">{errors.password.message}</FieldError>}
              </Field>

              {/* Confirmar Senha */}
              <Field className="flex flex-col gap-1.5">
                <FieldLabel className="text-xs uppercase tracking-widest font-bold opacity-70">Confirmar Senha</FieldLabel>
                <Input 
                  type="password" 
                  {...register("confirm_password")} 
                  placeholder="••••••••"
                  className="bg-background border-input focus:ring-ring"
                />
                {errors.confirm_password && <FieldError className="text-destructive text-xs">{errors.confirm_password.message}</FieldError>}
              </Field>

            </div>

            {/* Footer do Form com Termos e Botão */}
            <div className="pt-6 border-t border-border flex flex-col md:flex-row items-center justify-between gap-4">
              <div className="flex items-center gap-2 text-[10px] text-muted-foreground uppercase tracking-tight">
                <ShieldCheck size={14} className="text-success" />
                Seus dados estão protegidos por criptografia.
              </div>
              
              <Button 
                disabled={isSubmitting}
                className="w-full md:w-auto px-12 py-4 h-auto bg-primary text-primary-foreground hover:opacity-90 rounded-radius flex items-center gap-2 font-bold transition-all active:scale-95"
              >
                {isSubmitting ? "Processando..." : "Finalizar Cadastro"}
                <ArrowRight size={18} />
              </Button>
            </div>
          </form>
        </div>

        {/* Link para Login */}
        <div className="bg-muted/50 py-4 text-center border-t border-border">
          <p className="text-xs text-muted-foreground">
            Já possui uma conta? <a href="/auth" className="text-link font-bold hover:underline">Faça login</a>
          </p>
        </div>
      </div>
    </main>
  );
}