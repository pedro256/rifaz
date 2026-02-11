import { StrictMode } from 'react';
import { createRoot } from 'react-dom/client';
import './index.css';
import { ThemeProvider } from './contexts/ThemeContext';
import { AppProvider } from './contexts/AppContext';
import { RouterProvider } from 'react-router';
import Routes from './routes/Routes.tsx';

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <ThemeProvider>
      <AppProvider>
        <RouterProvider router={Routes}/>
      </AppProvider>
    </ThemeProvider>
  </StrictMode>
);
