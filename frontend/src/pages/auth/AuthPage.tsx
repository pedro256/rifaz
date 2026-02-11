import { Button } from "@/components/ui/button";

export default function AuthPage() {
  return (
    <main className="w-screen h-screen flex justify-center items-center">
      <div className=" rounded min-w-[40px] md:max-w-[40%] py-9 px-4 shadow-md ">
        <div>
          <h2 className="text-3xl font-bold text-white">Entrar</h2>
          <p className="italic opacity-70 bg-yellow-100">
            Caso já tenha uma conta e deseja gerenciar suas rifas, informe os
            dados abaixo
          </p>
        </div>
        <form action="">
          <Button>ok</Button>
        </form>
      </div>
    </main>
  );
}
