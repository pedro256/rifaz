"use client";
import {
  Plus,
  Search,
  Edit3,
  MoreVertical,
  Settings,
  TrendingUp,
  Eye,
  EyeOff,
} from "lucide-react";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { useState } from "react";

// Tipagem básica para as rifas
interface Rifa {
  id: string;
  titulo: string;
  status: "Ativa" | "Finalizada" | "Pausada";
  vendas: number;
  totalCotas: number;
  lucro: string;
}

const DashboardHome = () => {
  const [verTotalVendas, setVerTotalVendas] = useState(false);
  // Mock de dados para exemplificar
  const rifas: Rifa[] = [
    {
      id: "1",
      titulo: "iPhone 15 Pro Max",
      status: "Ativa",
      vendas: 450,
      totalCotas: 1000,
      lucro: "R$ 4.500,00",
    },
    {
      id: "2",
      titulo: "Playstation 5 + 2 Controles",
      status: "Pausada",
      vendas: 120,
      totalCotas: 500,
      lucro: "R$ 1.200,00",
    },
    {
      id: "3",
      titulo: "Pix de R$ 5.000,00",
      status: "Finalizada",
      vendas: 1000,
      totalCotas: 1000,
      lucro: "R$ 10.000,00",
    },
  ];

  return (
    <main className="flex-1 flex flex-col">
      {/* Topbar */}
      <header className="h-16 border-b border-border bg-card flex items-center justify-between px-8">
        <div></div>
        <div className="relative w-96">
          <Search
            className="absolute left-3 top-1/2 -translate-y-1/2 text-muted-foreground"
            size={16}
          />
          <Input
            placeholder="Buscar rifas..."
            className="pl-10 h-9 bg-muted/30 border-none rounded-radius"
          />
        </div>
        <div className="flex items-center gap-4">
          <Button variant="outline" size="sm" className="gap-2 rounded-radius">
            <Settings size={16} /> Configurações
          </Button>
          <Button
            size="sm"
            className="gap-2 rounded-radius bg-primary text-primary-foreground"
          >
            <Plus size={16} /> Nova Rifa
          </Button>
        </div>
      </header>

      {/* Dashboard Body */}
      <div className="p-8 space-y-8 overflow-y-auto">
        {/* Stats Overview */}
        <div className="grid grid-cols-1 md:grid-cols-3 gap-6">
          <div className="p-6 bg-card border border-border rounded-radius shadow-sm flex justify-between items-center">
            <div>
              <p className="text-xs font-bold text-muted-foreground uppercase tracking-widest mb-1">
                Total em Vendas
              </p>
              <h3 className="text-2xl font-bold">{
                verTotalVendas? 'R$ 15.700,40':(
                    <div className="h-8 w-24 bg-gray-300"></div>
                ) }</h3>
              <div className="mt-2 flex items-center gap-1 text-xs text-green-500 font-bold">
                <TrendingUp size={14} /> +12% este mês
              </div>
            </div>
            <div>
              <div onClick={() => setVerTotalVendas(!verTotalVendas)}>
                  {verTotalVendas ? <EyeOff size={28} /> : <Eye size={28} />}
              </div>
            
            </div>
          </div>
          <div className="p-6 bg-card border border-border rounded-radius shadow-sm select-none">
            <p className="text-xs font-bold text-muted-foreground uppercase tracking-widest mb-1">
              Rifas Ativas
            </p>
            <h3 className="text-2xl font-bold">02</h3>
          </div>
          <div className="p-6 bg-card border border-border rounded-radius shadow-sm select-none">
            <p className="text-xs font-bold text-muted-foreground uppercase tracking-widest mb-1">
              Total de Participantes
            </p>
            <h3 className="text-2xl font-bold">1.572</h3>
          </div>
        </div>

        {/* Rifas List Section */}
        <section className="space-y-4">
          <div className="flex justify-between items-center">
            <h2 className="text-xl font-bold tracking-tight">Suas Rifas</h2>
            <button className="text-sm font-bold text-primary hover:underline">
              Ver todas
            </button>
          </div>

          <div className="bg-card border border-border rounded-radius overflow-hidden">
            <table className="w-full text-left text-sm">
              <thead className="bg-muted/50 border-b border-border text-muted-foreground font-bold uppercase text-[10px] tracking-widest">
                <tr>
                  <th className="px-6 py-4">Nome da Rifa</th>
                  <th className="px-6 py-4">Status</th>
                  <th className="px-6 py-4">Progresso</th>
                  <th className="px-6 py-4 text-right">Ações</th>
                </tr>
              </thead>
              <tbody className="divide-y divide-border">
                {rifas.map((rifa) => (
                  <tr
                    key={rifa.id}
                    className="hover:bg-muted/20 transition-colors group"
                  >
                    <td className="px-6 py-4 font-bold">{rifa.titulo}</td>
                    <td className="px-6 py-4">
                      <span
                        className={`px-2 py-1 rounded-full text-[10px] font-black uppercase ${
                          rifa.status === "Ativa"
                            ? "bg-green-100 text-green-700"
                            : rifa.status === "Pausada"
                              ? "bg-yellow-100 text-yellow-700"
                              : "bg-slate-100 text-slate-700"
                        }`}
                      >
                        {rifa.status}
                      </span>
                    </td>
                    <td className="px-6 py-4 w-64">
                      <div className="flex flex-col gap-1.5">
                        <div className="flex justify-between text-[10px] font-bold">
                          <span>
                            {Math.round((rifa.vendas / rifa.totalCotas) * 100)}%
                          </span>
                          <span className="text-muted-foreground">
                            {rifa.vendas}/{rifa.totalCotas}
                          </span>
                        </div>
                        <div className="w-full h-1.5 bg-muted rounded-full overflow-hidden">
                          <div
                            className="h-full bg-primary transition-all duration-500"
                            style={{
                              width: `${(rifa.vendas / rifa.totalCotas) * 100}%`,
                            }}
                          />
                        </div>
                      </div>
                    </td>
                    <td className="px-6 py-4 text-right">
                      <div className="flex justify-end gap-2 opacity-0 group-hover:opacity-100 transition-opacity">
                        <Button
                          variant="ghost"
                          size="icon"
                          className="h-8 w-8 rounded-radius border border-border bg-background"
                        >
                          <Edit3 size={14} />
                        </Button>
                        <Button
                          variant="ghost"
                          size="icon"
                          className="h-8 w-8 rounded-radius"
                        >
                          <MoreVertical size={14} />
                        </Button>
                      </div>
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        </section>

        {/* Profile Quick Access (Opcional, pode ser um modal ou seção) */}
        <section className="p-8 bg-muted/30 border border-dashed border-border rounded-radius flex items-center justify-between">
          <div className="flex items-center gap-4">
            <div className="w-12 h-12 rounded-full bg-primary flex items-center justify-center text-primary-foreground font-bold">
              JS
            </div>
            <div>
              <h4 className="font-bold text-lg">Perfil de Organizador</h4>
              <p className="text-sm text-muted-foreground">
                Complete suas informações bancárias para receber via Pix.
              </p>
            </div>
          </div>
          <Button variant="secondary" className="rounded-radius font-bold">
            Completar Perfil
          </Button>
        </section>
      </div>
    </main>
  );
};

export default DashboardHome;
