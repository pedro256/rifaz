import { useState } from 'react';
import { Plus, Ticket } from 'lucide-react';
import { useApp } from '../contexts/AppContext';
import { CampaignForm } from './CampaignForm';
import { CampaignCard } from './CampaignCard';
import { CampaignDetail } from './CampaignDetail';
import { Campaign } from '../types';

export function CampaignsList() {
  const { campaigns, tickets } = useApp();
  const [showForm, setShowForm] = useState(false);
  const [selectedCampaign, setSelectedCampaign] = useState<Campaign | null>(null);

  const getSoldCount = (campaignId: string) => {
    return tickets.filter(
      (t) => t.campaignId === campaignId && t.status === 'paid'
    ).length;
  };

  if (selectedCampaign) {
    return (
      <CampaignDetail
        campaign={selectedCampaign}
        onBack={() => setSelectedCampaign(null)}
      />
    );
  }

  return (
    <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-8">
      <div className="flex items-center justify-between mb-8">
        <div>
          <h2 className="text-3xl font-bold text-primary">Campanhas Ativas</h2>
          <p className="text-secondary mt-2">
            Escolha uma campanha e compre seus números da sorte
          </p>
        </div>
        <button
          onClick={() => setShowForm(true)}
          className="btn-primary px-6 py-3 rounded-lg font-medium flex items-center gap-2"
        >
          <Plus size={20} />
          Nova Campanha
        </button>
      </div>

      {campaigns.length === 0 ? (
        <div className="text-center py-16">
          <Ticket className="mx-auto mb-4 text-secondary" size={64} />
          <h3 className="text-xl font-medium text-primary mb-2">
            Nenhuma campanha criada
          </h3>
          <p className="text-secondary mb-6">
            Crie sua primeira campanha para começar a vender rifas
          </p>
          <button
            onClick={() => setShowForm(true)}
            className="btn-primary px-6 py-3 rounded-lg font-medium inline-flex items-center gap-2"
          >
            <Plus size={20} />
            Criar Primeira Campanha
          </button>
        </div>
      ) : (
        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
          {campaigns
            .filter((c) => c.status === 'active')
            .map((campaign) => (
              <CampaignCard
                key={campaign.id}
                campaign={campaign}
                soldCount={getSoldCount(campaign.id)}
                onSelect={setSelectedCampaign}
              />
            ))}
        </div>
      )}

      {showForm && <CampaignForm onClose={() => setShowForm(false)} />}
    </div>
  );
}
