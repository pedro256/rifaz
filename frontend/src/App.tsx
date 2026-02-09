import { useState } from 'react';
import { Header } from './components/Header';
import { AdminDashboard } from './components/AdminDashboard';

function App() {
  const [currentView, setCurrentView] = useState<'campaigns' | 'admin'>('campaigns');

  return (
    <div className="min-h-screen bg-primary">
      <Header currentView={currentView} onViewChange={setCurrentView} />
      <AdminDashboard />
      {/* <main>
        {currentView === 'campaigns' ? <CampaignsList /> : <AdminDashboard />}
      </main> */}
    </div>
  );
}

export default App;
