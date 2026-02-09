import { useState } from 'react';
import { ShoppingCart, X } from 'lucide-react';
import { useApp } from '../contexts/AppContext';
import { Campaign } from '../types';

interface PurchaseFormProps {
  campaign: Campaign;
  selectedTickets: number[];
  onSuccess: () => void;
  onCancel: () => void;
}

export function PurchaseForm({ campaign, selectedTickets, onSuccess, onCancel }: PurchaseFormProps) {
  const { addBuyer, updateTicket, tickets } = useApp();
  const [formData, setFormData] = useState({
    name: '',
    email: '',
    phone: '',
    cpf: '',
  });

  const totalAmount = selectedTickets.length * campaign.ticketPrice;

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();

    const buyer = addBuyer(formData);

    selectedTickets.forEach((ticketNumber) => {
      const ticket = tickets.find(
        (t) => t.campaignId === campaign.id && t.ticketNumber === ticketNumber
      );
      if (ticket) {
        updateTicket(ticket.id, {
          buyerId: buyer.id,
          status: 'paid',
          paidAt: new Date().toISOString(),
        });
      }
    });

    onSuccess();
  };

  if (selectedTickets.length === 0) {
    return null;
  }

  return (
    <div className="bg-secondary rounded-lg p-6 sticky top-24">
      <div className="flex items-center justify-between mb-4">
        <h3 className="text-xl font-bold text-primary flex items-center gap-2">
          <ShoppingCart size={24} />
          Finalizar Compra
        </h3>
        <button
          onClick={onCancel}
          className="p-2 hover:bg-tertiary rounded-lg transition-colors"
        >
          <X size={20} />
        </button>
      </div>

      <div className="mb-4 p-4 bg-tertiary rounded-lg">
        <div className="flex justify-between items-center mb-2">
          <span className="text-secondary">Números selecionados:</span>
          <span className="text-primary font-bold">{selectedTickets.length}</span>
        </div>
        <div className="flex justify-between items-center">
          <span className="text-secondary">Total a pagar:</span>
          <span className="text-primary font-bold text-xl">
            R$ {totalAmount.toFixed(2)}
          </span>
        </div>
      </div>

      <div className="mb-4 p-3 bg-tertiary rounded-lg max-h-32 overflow-y-auto">
        <p className="text-sm text-secondary mb-2">Seus números:</p>
        <div className="flex flex-wrap gap-2">
          {selectedTickets.sort((a, b) => a - b).map((num) => (
            <span key={num} className="px-2 py-1 bg-blue-500 text-white rounded text-sm font-bold">
              {num}
            </span>
          ))}
        </div>
      </div>

      <form onSubmit={handleSubmit} className="space-y-4">
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
            placeholder="Seu nome completo"
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
            placeholder="seu@email.com"
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
            placeholder="(00) 00000-0000"
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
            placeholder="000.000.000-00"
          />
        </div>

        <button
          type="submit"
          className="w-full btn-primary px-6 py-3 rounded-lg font-medium"
        >
          Confirmar Compra
        </button>
      </form>
    </div>
  );
}
