import { Calendar, DollarSign, Ticket } from 'lucide-react';
import { Campaign } from '../types';

interface CampaignCardProps {
  campaign: Campaign;
  soldCount: number;
  onSelect: (campaign: Campaign) => void;
}

export function CampaignCard({ campaign, soldCount, onSelect }: CampaignCardProps) {
  const progress = (soldCount / campaign.totalTickets) * 100;
  const totalRevenue = soldCount * campaign.ticketPrice;

  return (
    <div
      onClick={() => onSelect(campaign)}
      className="bg-secondary rounded-lg overflow-hidden border border-custom hover:shadow-lg transition-all cursor-pointer"
    >
      {campaign.imageUrl && (
        <div className="h-48 overflow-hidden">
          <img
            src={campaign.imageUrl}
            alt={campaign.title}
            className="w-full h-full object-cover"
          />
        </div>
      )}
      <div className="p-6">
        <h3 className="text-xl font-bold text-primary mb-2">{campaign.title}</h3>
        {campaign.description && (
          <p className="text-secondary mb-4 line-clamp-2">{campaign.description}</p>
        )}

        <div className="space-y-3">
          <div className="flex items-center gap-2 text-secondary">
            <Calendar size={16} />
            <span className="text-sm">
              Sorteio: {new Date(campaign.drawDate).toLocaleDateString('pt-BR', {
                day: '2-digit',
                month: '2-digit',
                year: 'numeric',
                hour: '2-digit',
                minute: '2-digit'
              })}
            </span>
          </div>

          <div className="flex items-center gap-2 text-secondary">
            <DollarSign size={16} />
            <span className="text-sm">
              R$ {campaign.ticketPrice.toFixed(2)} por número
            </span>
          </div>

          <div className="flex items-center gap-2 text-secondary">
            <Ticket size={16} />
            <span className="text-sm">
              {soldCount} / {campaign.totalTickets} vendidos
            </span>
          </div>

          <div className="mt-4">
            <div className="flex justify-between text-sm mb-2">
              <span className="text-secondary">Progresso</span>
              <span className="text-primary font-medium">{progress.toFixed(1)}%</span>
            </div>
            <div className="w-full bg-tertiary rounded-full h-2 overflow-hidden">
              <div
                className="h-full btn-primary transition-all duration-500"
                style={{ width: `${progress}%` }}
              />
            </div>
          </div>

          <div className="mt-4 pt-4 border-t border-custom">
            <div className="flex justify-between items-center">
              <span className="text-secondary text-sm">Arrecadado</span>
              <span className="text-primary font-bold text-lg">
                R$ {totalRevenue.toFixed(2)}
              </span>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
