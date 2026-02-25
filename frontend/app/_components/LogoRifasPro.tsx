import { Rocket } from "lucide-react";

export default function LogoRifasPro() {
  return (
    <div title="Rifa Pro" className="flex items-center gap-2 select-none">
      <div className="bg-blue-600 p-1.5 rounded-lg">
        <Rocket className="text-white w-6 h-6" />
      </div>
      <span className="text-xl font-bold tracking-tight">
        Rifa<span className="text-blue-600">Pro</span>
      </span>
    </div>
  );
}
