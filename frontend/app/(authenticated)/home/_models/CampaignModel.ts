export default interface CampaignModel {
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