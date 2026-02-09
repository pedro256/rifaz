import { useState } from 'react';
import { DollarSign, Ticket, Users, TrendingUp, Plus } from 'lucide-react';
import { useApp } from '../contexts/AppContext';
import { ManualTicketForm } from './ManualTicketForm';

export function AdminDashboard() {
  const { campaigns, tickets, buyers } = useApp();
  const [selectedCampaign, setSelectedCampaign] = useState<string>('all');
  const [showManualForm, setShowManualForm] = useState(false);

  const filteredTickets =
    selectedCampaign === 'all'
      ? tickets
      : tickets.filter((t) => t.campaignId === selectedCampaign);

  const soldTickets = filteredTickets.filter((t) => t.status === 'paid');
  const totalRevenue = soldTickets.reduce((sum, ticket) => {
    const campaign = campaigns.find((c) => c.id === ticket.campaignId);
    return sum + (campaign?.ticketPrice || 0);
  }, 0);

  const activeCampaigns = campaigns.filter((c) => c.status === 'active').length;

  const campaignStats = campaigns.map((campaign) => {
    const campaignTickets = tickets.filter((t) => t.campaignId === campaign.id);
    const sold = campaignTickets.filter((t) => t.status === 'paid').length;
    const revenue = sold * campaign.ticketPrice;
    return {
      campaign,
      sold,
      available: campaignTickets.filter((t) => t.status === 'available').length,
      revenue,
      progress: (sold / campaign.totalTickets) * 100,
    };
  });

  const recentSales = soldTickets
    .sort((a, b) => {
      const dateA = new Date(a.paidAt || 0).getTime();
      const dateB = new Date(b.paidAt || 0).getTime();
      return dateB - dateA;
    })
    .slice(0, 10);

  return (
    <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-8">
      <div className="mb-8">
        <h2 className="text-3xl font-bold text-primary">Dashboard Administrativo</h2>
        <p className="text-secondary mt-2">Visão geral das suas rifas</p>
      </div>

      <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-6 mb-8">
        <div className="bg-secondary rounded-lg p-6 border-l-4 border-green-500">
          <div className="flex items-center justify-between">
            <div>
              <p className="text-secondary text-sm">Arrecadação Total</p>
              <p className="text-2xl font-bold text-primary mt-2">
                R$ {totalRevenue.toFixed(2)}
              </p>
            </div>
            <DollarSign className="text-green-500" size={40} />
          </div>
        </div>

        <div className="bg-secondary rounded-lg p-6 border-l-4 border-blue-500">
          <div className="flex items-center justify-between">
            <div>
              <p className="text-secondary text-sm">Rifas Vendidas</p>
              <p className="text-2xl font-bold text-primary mt-2">{soldTickets.length}</p>
            </div>
            <Ticket className="text-blue-500" size={40} />
          </div>
        </div>

        <div className="bg-secondary rounded-lg p-6 border-l-4 border-purple-500">
          <div className="flex items-center justify-between">
            <div>
              <p className="text-secondary text-sm">Campanhas Ativas</p>
              <p className="text-2xl font-bold text-primary mt-2">{activeCampaigns}</p>
            </div>
            <TrendingUp className="text-purple-500" size={40} />
          </div>
        </div>

        <div className="bg-secondary rounded-lg p-6 border-l-4 border-orange-500">
          <div className="flex items-center justify-between">
            <div>
              <p className="text-secondary text-sm">Total de Compradores</p>
              <p className="text-2xl font-bold text-primary mt-2">{buyers.length}</p>
            </div>
            <Users className="text-orange-500" size={40} />
          </div>
        </div>
      </div>

      <div className="grid grid-cols-1 lg:grid-cols-2 gap-6 mb-8">
        <div className="bg-secondary rounded-lg p-6">
          <div className="flex items-center justify-between mb-6">
            <h3 className="text-xl font-bold text-primary">Estatísticas por Campanha</h3>
            <select
              value={selectedCampaign}
              onChange={(e) => setSelectedCampaign(e.target.value)}
              className="px-4 py-2 bg-tertiary border border-custom rounded-lg text-primary focus:outline-none"
            >
              <option value="all">Todas as Campanhas</option>
              {campaigns.map((campaign) => (
                <option key={campaign.id} value={campaign.id}>
                  {campaign.title}
                </option>
              ))}
            </select>
          </div>

          <div className="space-y-4">
            {campaignStats.map((stat) => (
              <div key={stat.campaign.id} className="border border-custom rounded-lg p-4">
                <div className="flex justify-between items-start mb-3">
                  <div>
                    <h4 className="font-medium text-primary">{stat.campaign.title}</h4>
                    <p className="text-sm text-secondary mt-1">
                      {stat.sold} / {stat.campaign.totalTickets} vendidos
                    </p>
                  </div>
                  <span className="text-lg font-bold text-primary">
                    R$ {stat.revenue.toFixed(2)}
                  </span>
                </div>
                <div className="w-full bg-tertiary rounded-full h-2 overflow-hidden">
                  <div
                    className="h-full btn-primary transition-all duration-500"
                    style={{ width: `${stat.progress}%` }}
                  />
                </div>
                <div className="flex justify-between mt-2 text-xs text-secondary">
                  <span>{stat.available} disponíveis</span>
                  <span>{stat.progress.toFixed(1)}%</span>
                </div>
              </div>
            ))}
          </div>
        </div>

        <div className="bg-secondary rounded-lg p-6">
          <div className="flex items-center justify-between mb-6">
            <h3 className="text-xl font-bold text-primary">Vendas Recentes</h3>
            <button
              onClick={() => setShowManualForm(true)}
              className="btn-primary px-4 py-2 rounded-lg text-sm font-medium flex items-center gap-2"
            >
              <Plus size={16} />
              Adicionar Manualmente
            </button>
          </div>

          <div className="space-y-3 max-h-[500px] overflow-y-auto">
            {recentSales.length === 0 ? (
              <p className="text-center text-secondary py-8">
                Nenhuma venda registrada ainda
              </p>
            ) : (
              recentSales.map((ticket) => {
                const campaign = campaigns.find((c) => c.id === ticket.campaignId);
                const buyer = buyers.find((b) => b.id === ticket.buyerId);
                return (
                  <div
                    key={ticket.id}
                    className="flex items-center justify-between p-3 bg-tertiary rounded-lg"
                  >
                    <div>
                      <p className="font-medium text-primary">
                        Número {ticket.ticketNumber}
                      </p>
                      <p className="text-sm text-secondary">{campaign?.title}</p>
                      <p className="text-xs text-secondary">{buyer?.name}</p>
                    </div>
                    <div className="text-right">
                      <p className="font-bold text-primary">
                        R$ {campaign?.ticketPrice.toFixed(2)}
                      </p>
                      <p className="text-xs text-secondary">
                        {ticket.paidAt &&
                          new Date(ticket.paidAt).toLocaleDateString('pt-BR')}
                      </p>
                    </div>
                  </div>
                );
              })
            )}
          </div>
        </div>
      </div>

      <div className="bg-secondary rounded-lg p-6">
        <h3 className="text-xl font-bold text-primary mb-6">Lista de Compradores</h3>
        <div className="overflow-x-auto">
          <table className="w-full">
            <thead>
              <tr className="border-b border-custom">
                <th className="text-left py-3 px-4 text-secondary font-medium">Nome</th>
                <th className="text-left py-3 px-4 text-secondary font-medium">Email</th>
                <th className="text-left py-3 px-4 text-secondary font-medium">Telefone</th>
                <th className="text-left py-3 px-4 text-secondary font-medium">CPF</th>
                <th className="text-left py-3 px-4 text-secondary font-medium">
                  Rifas Compradas
                </th>
              </tr>
            </thead>
            <tbody>
              {buyers.map((buyer) => {
                const buyerTickets = tickets.filter(
                  (t) => t.buyerId === buyer.id && t.status === 'paid'
                );
                return (
                  <tr key={buyer.id} className="border-b border-custom hover:bg-tertiary">
                    <td className="py-3 px-4 text-primary">{buyer.name}</td>
                    <td className="py-3 px-4 text-secondary">{buyer.email}</td>
                    <td className="py-3 px-4 text-secondary">{buyer.phone}</td>
                    <td className="py-3 px-4 text-secondary">{buyer.cpf}</td>
                    <td className="py-3 px-4 text-primary font-medium">
                      {buyerTickets.length}
                    </td>
                  </tr>
                );
              })}
            </tbody>
          </table>
          {buyers.length === 0 && (
            <p className="text-center text-secondary py-8">
              Nenhum comprador cadastrado ainda
            </p>
          )}
        </div>
      </div>

      {showManualForm && <ManualTicketForm onClose={() => setShowManualForm(false)} />}
    </div>
  );
}
