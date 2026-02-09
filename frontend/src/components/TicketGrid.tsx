import { Ticket } from '../types';

interface TicketGridProps {
  tickets: Ticket[];
  selectedTickets: number[];
  onToggleTicket: (ticketNumber: number) => void;
}

export function TicketGrid({ tickets, selectedTickets, onToggleTicket }: TicketGridProps) {
  return (
    <div className="space-y-6">
      <div className="flex flex-wrap gap-4 justify-center p-4 bg-secondary rounded-lg">
        <div className="flex items-center gap-2">
          <div className="w-6 h-6 ticket-available rounded"></div>
          <span className="text-sm text-secondary">Disponível</span>
        </div>
        <div className="flex items-center gap-2">
          <div className="w-6 h-6 ticket-reserved rounded"></div>
          <span className="text-sm text-secondary">Reservado</span>
        </div>
        <div className="flex items-center gap-2">
          <div className="w-6 h-6 ticket-paid rounded"></div>
          <span className="text-sm text-secondary">Vendido</span>
        </div>
        <div className="flex items-center gap-2">
          <div className="w-6 h-6 bg-blue-500 rounded"></div>
          <span className="text-sm text-secondary">Selecionado</span>
        </div>
      </div>

      <div className="grid grid-cols-5 sm:grid-cols-10 md:grid-cols-15 lg:grid-cols-20 gap-2">
        {tickets
          .sort((a, b) => a.ticketNumber - b.ticketNumber)
          .map((ticket) => {
            const isSelected = selectedTickets.includes(ticket.ticketNumber);
            const isAvailable = ticket.status === 'available';

            return (
              <button
                key={ticket.id}
                onClick={() => isAvailable && onToggleTicket(ticket.ticketNumber)}
                disabled={!isAvailable}
                className={`
                  aspect-square rounded-lg font-bold text-sm transition-all
                  ${isSelected
                    ? 'bg-blue-500 text-white scale-110 shadow-lg'
                    : ticket.status === 'available'
                    ? 'ticket-available text-white hover:scale-105 cursor-pointer'
                    : ticket.status === 'reserved'
                    ? 'ticket-reserved text-white cursor-not-allowed opacity-75'
                    : 'ticket-paid text-white cursor-not-allowed opacity-75'
                  }
                `}
                title={`Número ${ticket.ticketNumber} - ${
                  isSelected
                    ? 'Selecionado'
                    : ticket.status === 'available'
                    ? 'Disponível'
                    : ticket.status === 'reserved'
                    ? 'Reservado'
                    : 'Vendido'
                }`}
              >
                {ticket.ticketNumber}
              </button>
            );
          })}
      </div>
    </div>
  );
}
