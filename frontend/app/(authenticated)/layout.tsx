import { User, LayoutDashboard, Ticket} from "lucide-react";
import LogoRifasPro from "../_components/LogoRifasPro";
import SidebarSignOut from "./_components/sidebar-signout/SidebarSignOut";
import { getServerSession } from "next-auth";

export default async function LayoutAuthenticatedArea({
  children,
}: {
  children: React.ReactNode;
}) {
  const session = await getServerSession();
  return (
    <div className="flex min-h-screen bg-background text-foreground">
      {/* --- SIDEBAR --- */}
      <aside className="w-64 bg-card border-r border-border shadow-md hidden md:flex flex-col">
        <div className="p-6">
          <LogoRifasPro />
        </div>

        <nav className="flex-1 px-4 space-y-1 mt-4">
          <a
            href="#"
            className="flex items-center gap-3 px-3 py-2 bg-sidebar-accent text-sidebar-accent-foreground rounded-radius font-medium"
          >
            <LayoutDashboard size={18} /> Dashboard
          </a>
          <a
            href="#"
            className="flex items-center gap-3 px-3 py-2 text-muted-foreground hover:bg-sidebar-accent hover:text-sidebar-accent-foreground rounded-radius transition-all"
          >
            <Ticket size={18} /> Minhas Rifas
          </a>
          {/* <a
            href="#"
            className="flex items-center gap-3 px-3 py-2 text-muted-foreground hover:bg-sidebar-accent hover:text-sidebar-accent-foreground rounded-radius transition-all"
          >
            <Users size={18} /> Clientes
          </a> */}
        </nav>

        <div className="p-4 border-t border-border-divider">
          <div className="flex items-center gap-3 px-3 py-2 mb-2">
           
            <div className="w-8 h-8 rounded-full bg-muted flex items-center justify-center border border-border">
              <User size={16} />
            </div>
            <div className="flex flex-col overflow-hidden">
              <span className="text-sm font-bold truncate">{session?.user?.name}</span>
              <span className="text-[10px] text-muted-foreground truncate italic">
                Pro Account
              </span>
            </div>
          </div>
          <SidebarSignOut/>
        </div>
      </aside>
      {children}
    </div>
  );
}
