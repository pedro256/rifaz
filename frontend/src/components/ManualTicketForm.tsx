import { useState } from 'react';
import { X, Plus } from 'lucide-react';
import { useApp } from '../contexts/AppContext';

interface ManualTicketFormProps {
  onClose: () => void;
}

export function ManualTicketForm({ onClose }: ManualTicketFormProps) {
  const { campaigns, tickets, addBuyer, updateTicket } = useApp();
  const [selectedCampaign, setSelectedCampaign] = useState('');
  const [ticketNumbers, setTicketNumbers] = useState('');
  const [formData, setFormData] = useState({
    name: '',
    email: '',
    phone: '',
    cpf: '',
  });

  const availableTickets = selectedCampaign
    ? tickets.filter(
        (t) => t.campaignId === selectedCampaign && t.status === 'available'
      )
    : [];

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();

    const numbers = ticketNumbers
      .split(',')
      .map((n) => parseInt(n.trim()))
      .filter((n) => !isNaN(n));

    if (numbers.length === 0) {
      alert('Por favor, insira números válidos');
      return;
    }

    const buyer = addBuyer(formData);

    numbers.forEach((ticketNumber) => {
      const ticket = tickets.find(
        (t) =>
          t.campaignId === selectedCampaign &&
          t.ticketNumber === ticketNumber &&
          t.status === 'available'
      );
      if (ticket) {
        updateTicket(ticket.id, {
          buyerId: buyer.id,
          status: 'paid',
          paidAt: new Date().toISOString(),
        });
      }
    });

    alert(`${numbers.length} rifas adicionadas com sucesso!`);
    onClose();
  };

  return (
    <div className="fixed inset-0 bg-black bg-opacity-50 flex items-center justify-center p-4 z-50">
      <div className="bg-secondary rounded-lg max-w-2xl w-full max-h-[90vh] overflow-y-auto">
        <div className="p-6">
          <div className="flex items-center justify-between mb-6">
            <h2 className="text-2xl font-bold text-primary">Adicionar Rifa Manualmente</h2>
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
                Campanha
              </label>
              <select
                required
                value={selectedCampaign}
                onChange={(e) => setSelectedCampaign(e.target.value)}
                className="w-full px-4 py-2 bg-tertiary border border-custom rounded-lg text-primary focus:outline-none focus:ring-2 focus:ring-opacity-50"
              >
                <option value="">Selecione uma campanha</option>
                {campaigns
                  .filter((c) => c.status === 'active')
                  .map((campaign) => (
                    <option key={campaign.id} value={campaign.id}>
                      {campaign.title}
                    </option>
                  ))}
              </select>
            </div>

            {selectedCampaign && (
              <div className="p-3 bg-tertiary rounded-lg">
                <p className="text-sm text-secondary">
                  Números disponíveis: {availableTickets.length}
                </p>
              </div>
            )}

            <div>
              <label className="block text-sm font-medium text-primary mb-2">
                Números (separados por vírgula)
              </label>
              <input
                type="text"
                required
                value={ticketNumbers}
                onChange={(e) => setTicketNumbers(e.target.value)}
                className="w-full px-4 py-2 bg-tertiary border border-custom rounded-lg text-primary focus:outline-none focus:ring-2 focus:ring-opacity-50"
                placeholder="Ex: 1, 5, 10, 25"
              />
              <p className="text-xs text-secondary mt-1">
                Digite os números separados por vírgula
              </p>
            </div>

            <div className="border-t border-custom pt-4">
              <h3 className="text-lg font-medium text-primary mb-4">
                Dados do Comprador
              </h3>

              <div className="space-y-4">
                <div>
                  <label className="block text-sm font-medium text-primary mb-2">
                    Nome Completo
                  </label>
                  <input
                    type="text"
                    required
                    value={formData.name}
                    onChange={(e) => setFormData({ ...formData, name: e.target.value })}
                    className="w-full px-4 py-2 bg-tertiary border border-custom rounded-lg text-primary focus:outline-none focus:ring-2 focus:ring-opacity-50"
                  />
                </div>

                <div>
                  <label className="block text-sm font-medium text-primary mb-2">
                    Email
                  </label>
                  <input
                    type="email"
                    required
                    value={formData.email}
                    onChange={(e) => setFormData({ ...formData, email: e.target.value })}
                    className="w-full px-4 py-2 bg-tertiary border border-custom rounded-lg text-primary focus:outline-none focus:ring-2 focus:ring-opacity-50"
                  />
                </div>

                <div>
                  <label className="block text-sm font-medium text-primary mb-2">
                    Telefone
                  </label>
                  <input
                    type="tel"
                    required
                    value={formData.phone}
                    onChange={(e) => setFormData({ ...formData, phone: e.target.value })}
                    className="w-full px-4 py-2 bg-tertiary border border-custom rounded-lg text-primary focus:outline-none focus:ring-2 focus:ring-opacity-50"
                  />
                </div>

                <div>
                  <label className="block text-sm font-medium text-primary mb-2">
                    CPF
                  </label>
                  <input
                    type="text"
                    required
                    value={formData.cpf}
                    onChange={(e) => setFormData({ ...formData, cpf: e.target.value })}
                    className="w-full px-4 py-2 bg-tertiary border border-custom rounded-lg text-primary focus:outline-none focus:ring-2 focus:ring-opacity-50"
                  />
                </div>
              </div>
            </div>

            <div className="flex gap-3 pt-4">
              <button
                type="submit"
                className="flex-1 btn-primary px-6 py-3 rounded-lg font-medium flex items-center justify-center gap-2"
              >
                <Plus size={20} />
                Adicionar Rifas
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
