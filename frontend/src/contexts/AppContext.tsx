import { createContext, useContext, useState, ReactNode } from 'react';
import { Campaign, Ticket, Buyer } from '../types';

interface AppContextType {
  campaigns: Campaign[];
  tickets: Ticket[];
  buyers: Buyer[];
  addCampaign: (campaign: Omit<Campaign, 'id' | 'createdAt'>) => void;
  addTicket: (ticket: Omit<Ticket, 'id'>) => void;
  updateTicket: (id: string, updates: Partial<Ticket>) => void;
  addBuyer: (buyer: Omit<Buyer, 'id' | 'createdAt'>) => Buyer;
}

const AppContext = createContext<AppContextType | undefined>(undefined);

export function AppProvider({ children }: { children: ReactNode }) {
  const [campaigns, setCampaigns] = useState<Campaign[]>([]);
  const [tickets, setTickets] = useState<Ticket[]>([]);
  const [buyers, setBuyers] = useState<Buyer[]>([]);

  const addCampaign = (campaign: Omit<Campaign, 'id' | 'createdAt'>) => {
    const newCampaign: Campaign = {
      ...campaign,
      id: crypto.randomUUID(),
      createdAt: new Date().toISOString(),
    };
    setCampaigns(prev => [...prev, newCampaign]);

    const newTickets: Ticket[] = [];
    for (let i = 1; i <= campaign.totalTickets; i++) {
      newTickets.push({
        id: crypto.randomUUID(),
        campaignId: newCampaign.id,
        ticketNumber: i,
        status: 'available',
      });
    }
    setTickets(prev => [...prev, ...newTickets]);
  };

  const addTicket = (ticket: Omit<Ticket, 'id'>) => {
    const newTicket: Ticket = {
      ...ticket,
      id: crypto.randomUUID(),
    };
    setTickets(prev => [...prev, newTicket]);
  };

  const updateTicket = (id: string, updates: Partial<Ticket>) => {
    setTickets(prev =>
      prev.map(ticket => (ticket.id === id ? { ...ticket, ...updates } : ticket))
    );
  };

  const addBuyer = (buyer: Omit<Buyer, 'id' | 'createdAt'>): Buyer => {
    const newBuyer: Buyer = {
      ...buyer,
      id: crypto.randomUUID(),
      createdAt: new Date().toISOString(),
    };
    setBuyers(prev => [...prev, newBuyer]);
    return newBuyer;
  };

  return (
    <AppContext.Provider
      value={{
        campaigns,
        tickets,
        buyers,
        addCampaign,
        addTicket,
        updateTicket,
        addBuyer,
      }}
    >
      {children}
    </AppContext.Provider>
  );
}

export function useApp() {
  const context = useContext(AppContext);
  if (!context) {
    throw new Error('useApp must be used within AppProvider');
  }
  return context;
}
