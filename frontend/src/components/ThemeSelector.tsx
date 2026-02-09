import { Sun, Flame, Moon } from 'lucide-react';
import { useTheme } from '../contexts/ThemeContext';

export function ThemeSelector() {
  const { theme, setTheme } = useTheme();

  return (
    <div className="flex gap-2 p-1 bg-secondary rounded-lg">
      <button
        onClick={() => setTheme('light')}
        className={`p-2 rounded-md transition-all ${
          theme === 'light' ? 'btn-primary' : 'hover:bg-tertiary'
        }`}
        title="Tema Claro"
      >
        <Sun size={20} />
      </button>
      <button
        onClick={() => setTheme('hot')}
        className={`p-2 rounded-md transition-all ${
          theme === 'hot' ? 'btn-primary' : 'hover:bg-tertiary'
        }`}
        title="Tema Quente"
      >
        <Flame size={20} />
      </button>
      <button
        onClick={() => setTheme('dark')}
        className={`p-2 rounded-md transition-all ${
          theme === 'dark' ? 'btn-primary' : 'hover:bg-tertiary'
        }`}
        title="Tema Escuro"
      >
        <Moon size={20} />
      </button>
    </div>
  );
}
