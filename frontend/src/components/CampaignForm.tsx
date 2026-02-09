import { useState } from 'react';
import { Plus, X } from 'lucide-react';
import { useApp } from '../contexts/AppContext';

interface CampaignFormProps {
  onClose: () => void;
}

export function CampaignForm({ onClose }: CampaignFormProps) {
  const { addCampaign } = useApp();
  const [formData, setFormData] = useState({
    title: '',
    description: '',
    totalTickets: 100,
    ticketPrice: 10,
    drawDate: '',
    imageUrl: '',
  });

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    addCampaign({
      ...formData,
      status: 'active',
    });
    onClose();
  };

  return (
    <div className="fixed inset-0 bg-black bg-opacity-50 flex items-center justify-center p-4 z-50">
      <div className="bg-secondary rounded-lg max-w-2xl w-full max-h-[90vh] overflow-y-auto">
        <div className="p-6">
          <div className="flex items-center justify-between mb-6">
            <h2 className="text-2xl font-bold text-primary">Nova Campanha</h2>
            <button
              onClick={onClose}
              className="p-2 hover:bg-tertiary rounded-lg transition-colors"
            >
              <X size={20} />
            </button>
          </div>

          <form onSubmit={handleSubmit} className="space-y-4">
            <div>
              <label className="block text-sm font-medium text-primary mb-2">
                Título da Campanha
              </label>
              <input
                type="text"
                required
                value={formData.title}
                onChange={(e) => setFormData({ ...formData, title: e.target.value })}
                className="w-full px-4 py-2 bg-tertiary border border-custom rounded-lg text-primary focus:outline-none focus:ring-2 focus:ring-opacity-50"
                placeholder="Ex: Rifa do Carro 0km"
              />
            </div>

            <div>
              <label className="block text-sm font-medium text-primary mb-2">
                Descrição
              </label>
              <textarea
                value={formData.description}
                onChange={(e) => setFormData({ ...formData, description: e.target.value })}
                className="w-full px-4 py-2 bg-tertiary border border-custom rounded-lg text-primary focus:outline-none focus:ring-2 focus:ring-opacity-50"
                rows={3}
                placeholder="Descreva os prêmios e detalhes da rifa"
              />
            </div>

            <div className="grid grid-cols-2 gap-4">
              <div>
                <label className="block text-sm font-medium text-primary mb-2">
                  Quantidade de Números
                </label>
                <input
                  type="number"
                  required
                  min="1"
                  value={formData.totalTickets}
                  onChange={(e) => setFormData({ ...formData, totalTickets: parseInt(e.target.value) })}
                  className="w-full px-4 py-2 bg-tertiary border border-custom rounded-lg text-primary focus:outline-none focus:ring-2 focus:ring-opacity-50"
                />
              </div>

              <div>
                <label className="block text-sm font-medium text-primary mb-2">
                  Preço por Número (R$)
                </label>
                <input
                  type="number"
                  required
                  min="0"
                  step="0.01"
                  value={formData.ticketPrice}
                  onChange={(e) => setFormData({ ...formData, ticketPrice: parseFloat(e.target.value) })}
                  className="w-full px-4 py-2 bg-tertiary border border-custom rounded-lg text-primary focus:outline-none focus:ring-2 focus:ring-opacity-50"
                />
              </div>
            </div>

            <div>
              <label className="block text-sm font-medium text-primary mb-2">
                Data do Sorteio
              </label>
              <input
                type="datetime-local"
                required
                value={formData.drawDate}
                onChange={(e) => setFormData({ ...formData, drawDate: e.target.value })}
                className="w-full px-4 py-2 bg-tertiary border border-custom rounded-lg text-primary focus:outline-none focus:ring-2 focus:ring-opacity-50"
              />
            </div>

            <div>
              <label className="block text-sm font-medium text-primary mb-2">
                URL da Imagem
              </label>
              <input
                type="url"
                value={formData.imageUrl}
                onChange={(e) => setFormData({ ...formData, imageUrl: e.target.value })}
                className="w-full px-4 py-2 bg-tertiary border border-custom rounded-lg text-primary focus:outline-none focus:ring-2 focus:ring-opacity-50"
                placeholder="https://exemplo.com/imagem.jpg"
              />
            </div>

            <div className="flex gap-3 pt-4">
              <button
                type="submit"
                className="flex-1 btn-primary px-6 py-3 rounded-lg font-medium flex items-center justify-center gap-2"
              >
                <Plus size={20} />
                Criar Campanha
              </button>
              <button
                type="button"
                onClick={onClose}
                className="px-6 py-3 bg-tertiary hover:bg-opacity-80 rounded-lg font-medium transition-colors"
              >
                Cancelar
              </button>
            </div>
          </form>
        </div>
      </div>
    </div>
  );
}
