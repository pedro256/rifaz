export default interface TicketModel {
  id: string;
  campaignId: string;
  ticketNumber: number;
  buyerId?: string;
  status: 'available' | 'reserved' | 'paid';
  reservedAt?: string;
  paidAt?: string;
}