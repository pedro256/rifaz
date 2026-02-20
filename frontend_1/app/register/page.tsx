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

export default function RegisterPage() {
  const {
    register,
    formState: { errors },
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
      const result = await registerUserAction(formData);
      //  dialog.success({
      //   title:"Cadastro Realizado com Sucesso !",
      //   description: ""
      // })
      // console.log(result);
      toast.success("Usuário Registrado.",{position:"top-center"})
      route.push("/auth")
    } catch (e:any){
      dialog.error({
        title:"Erro ao Cadastrar",
        description:e.message
      })
    }

  }

  return (
    <main className="flex justify-center mt-12">
      <div className="border w-[70%] py-8 px-6 rounded">
        <h2 className="text-3xl font-medium">Cadastre-se !</h2>
        <p className="opacity-70">Informe os dados fundamentais para podermos prosseguir com o cadastro.</p>
        <div className="mt-8">
          <form onSubmit={handleSubmit(onSubmit)} className="grid grid-cols-2 gap-4">
            <Field className="col-span-1">
              <FieldLabel>Nome Completo:</FieldLabel>
              <Input {...register("fullname")} name="fullname" />
              {errors.fullname && <FieldError>{errors.fullname.message}</FieldError>}
            </Field>
            <Field className="col-span-1">
              <FieldLabel>Email:</FieldLabel>
              <Input type="email"{...register("email")} />
              {errors.email && <FieldError>{errors.email.message}</FieldError>}
            </Field>
            <Field className="col-span-1">
              <FieldLabel>Senha:</FieldLabel>
              <Input type="password" {...register("password")} name="password" />
              {errors.password && <FieldError>{errors.password.message}</FieldError>}
            </Field>
            <Field className="col-span-1">
              <FieldLabel>Repita a Senha:</FieldLabel>
              <Input type="password" {...register("confirm_password")} name="confirm_password" />
              {errors.confirm_password && <FieldError>{errors.confirm_password.message}</FieldError>}
            </Field>
            <div className="col-span-2 flex justify-end py-4">
              <Button>Cadastrar</Button>
            </div>

          </form>
        </div>
      </div>
    </main>
  );
}
