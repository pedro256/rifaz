import { Ticket, LayoutDashboard } from 'lucide-react';
import { ThemeSelector } from './ThemeSelector';

interface HeaderProps {
  currentView: 'campaigns' | 'admin';
  onViewChange: (view: 'campaigns' | 'admin') => void;
}

export function Header({ currentView, onViewChange }: HeaderProps) {
  return (
    <header className="bg-secondary border-b border-custom sticky top-0 z-50">
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-4">
        <div className="flex items-center justify-between">
          <div className="flex items-center gap-3">
            <Ticket className="text-primary" size={32} />
            <h1 className="text-2xl font-bold text-primary">Sistema de Rifas</h1>
          </div>

          <div className="flex items-center gap-4">
            <nav className="flex gap-2">
              <button
                onClick={() => onViewChange('campaigns')}
                className={`px-4 py-2 rounded-lg transition-all flex items-center gap-2 ${
                  currentView === 'campaigns'
                    ? 'btn-primary'
                    : 'hover:bg-tertiary text-secondary'
                }`}
              >
                <Ticket size={18} />
                Campanhas
              </button>
              <button
                onClick={() => onViewChange('admin')}
                className={`px-4 py-2 rounded-lg transition-all flex items-center gap-2 ${
                  currentView === 'admin'
                    ? 'btn-primary'
                    : 'hover:bg-tertiary text-secondary'
                }`}
              >
                <LayoutDashboard size={18} />
                Administração
              </button>
            </nav>

            <ThemeSelector />
          </div>
        </div>
      </div>
    </header>
  );
}
