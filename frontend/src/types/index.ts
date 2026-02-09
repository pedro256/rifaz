export interface Campaign {
  id: string;
  title: string;
  description: string;
  totalTickets: number;
  ticketPrice: number;
  drawDate: string;
  imageUrl: string;
  status: 'active' | 'finished' | 'cancelled';
  createdAt: string;
}

export interface Ticket {
  id: string;
  campaignId: string;
  ticketNumber: number;
  buyerId?: string;
  status: 'available' | 'reserved' | 'paid';
  reservedAt?: string;
  paidAt?: string;
}

export interface Buyer {
  id: string;
  name: string;
  email: string;
  phone: string;
  cpf: string;
  createdAt: string;
}
