import { useState } from 'react';
import { ArrowLeft, Calendar, DollarSign } from 'lucide-react';
import { Campaign } from '../types';
import { useApp } from '../contexts/AppContext';
import { TicketGrid } from './TicketGrid';
import { PurchaseForm } from './PurchaseForm';

interface CampaignDetailProps {
  campaign: Campaign;
  onBack: () => void;
}

export function CampaignDetail({ campaign, onBack }: CampaignDetailProps) {
  const { tickets } = useApp();
  const [selectedTickets, setSelectedTickets] = useState<number[]>([]);
  const [showSuccess, setShowSuccess] = useState(false);

  const campaignTickets = tickets.filter((t) => t.campaignId === campaign.id);
  const soldCount = campaignTickets.filter((t) => t.status === 'paid').length;
  const availableCount = campaignTickets.filter((t) => t.status === 'available').length;

  const handleToggleTicket = (ticketNumber: number) => {
    setSelectedTickets((prev) =>
      prev.includes(ticketNumber)
        ? prev.filter((n) => n !== ticketNumber)
        : [...prev, ticketNumber]
    );
  };

  const handlePurchaseSuccess = () => {
    setShowSuccess(true);
    setSelectedTickets([]);
    setTimeout(() => setShowSuccess(false), 3000);
  };

  return (
    <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-8">
      <button
        onClick={onBack}
        className="mb-6 flex items-center gap-2 text-secondary hover:text-primary transition-colors"
      >
        <ArrowLeft size={20} />
        Voltar para campanhas
      </button>

      {showSuccess && (
        <div className="mb-6 p-4 bg-green-500 text-white rounded-lg text-center font-medium animate-pulse">
          Compra realizada com sucesso! Boa sorte!
        </div>
      )}

      <div className="grid grid-cols-1 lg:grid-cols-3 gap-8">
        <div className="lg:col-span-2 space-y-6">
          <div className="bg-secondary rounded-lg p-6">
            {campaign.imageUrl && (
              <div className="mb-6 rounded-lg overflow-hidden">
                <img
                  src={campaign.imageUrl}
                  alt={campaign.title}
                  className="w-full h-64 object-cover"
                />
              </div>
            )}

            <h1 className="text-3xl font-bold text-primary mb-4">{campaign.title}</h1>

            {campaign.description && (
              <p className="text-secondary mb-6">{campaign.description}</p>
            )}

            <div className="grid grid-cols-2 gap-4">
              <div className="flex items-center gap-3 p-4 bg-tertiary rounded-lg">
                <Calendar className="text-primary" size={24} />
                <div>
                  <p className="text-xs text-secondary">Data do Sorteio</p>
                  <p className="text-sm font-medium text-primary">
                    {new Date(campaign.drawDate).toLocaleDateString('pt-BR')}
                  </p>
                </div>
              </div>

              <div className="flex items-center gap-3 p-4 bg-tertiary rounded-lg">
                <DollarSign className="text-primary" size={24} />
                <div>
                  <p className="text-xs text-secondary">Valor por Número</p>
                  <p className="text-sm font-medium text-primary">
                    R$ {campaign.ticketPrice.toFixed(2)}
                  </p>
                </div>
              </div>

              <div className="flex items-center gap-3 p-4 bg-tertiary rounded-lg">
                <div className="w-6 h-6 ticket-available rounded"></div>
                <div>
                  <p className="text-xs text-secondary">Disponíveis</p>
                  <p className="text-sm font-medium text-primary">{availableCount}</p>
                </div>
              </div>

              <div className="flex items-center gap-3 p-4 bg-tertiary rounded-lg">
                <div className="w-6 h-6 ticket-paid rounded"></div>
                <div>
                  <p className="text-xs text-secondary">Vendidos</p>
                  <p className="text-sm font-medium text-primary">{soldCount}</p>
                </div>
              </div>
            </div>
          </div>

          <div className="bg-secondary rounded-lg p-6">
            <h2 className="text-2xl font-bold text-primary mb-6">
              Escolha seus números
            </h2>
            <TicketGrid
              tickets={campaignTickets}
              selectedTickets={selectedTickets}
              onToggleTicket={handleToggleTicket}
            />
          </div>
        </div>

        <div>
          <PurchaseForm
            campaign={campaign}
            selectedTickets={selectedTickets}
            onSuccess={handlePurchaseSuccess}
            onCancel={() => setSelectedTickets([])}
          />
        </div>
      </div>
    </div>
  );
}
