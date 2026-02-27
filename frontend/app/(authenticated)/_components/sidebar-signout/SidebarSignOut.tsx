'use client';
import { LogOut } from "lucide-react";
import { signOut } from "next-auth/react";

export default function SidebarSignOut() {
  return (
    <button
      onClick={() => signOut()}
      className="flex items-center gap-3 w-full px-3 py-2 text-destructive hover:bg-destructive/10 rounded-radius transition-all text-sm font-medium"
    >
      <LogOut size={16} /> Sair
    </button>
  );
}
