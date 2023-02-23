using App.Rifas.Core.DataAccess.Entities.CategoriesRaflleTicket;
using App.Rifas.Core.DataAccess.Entities.RaffleTickets;
using App.Rifas.Core.DataAccess.Repositories.Raffle;
using App.Rifas.Core.DataAccess.Repositories.RaffleTicket;
using App.Rifas.Core.DataAccess.Repositories.User;
using App.Rifas.Core.Mapping.Exceptions;
using App.Rifas.Core.Mapping.Filters;
using App.Rifas.Core.Mapping.InputModel.RaffleTicket;
using App.Rifas.Core.Mapping.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Rifas.Core.Bll.RaffleTicket
{
    public class RaffleTicketsBll : IRaffleTicketBll
    {
        IRaffleTicketRepository raffleTicketRepository;
        IRaffleRepository raffleRepository;
        IUserRepository userRepository;


        public RaffleTicketsBll(
            IRaffleTicketRepository raffleTicketRepository,
            IRaffleRepository raffleRepository,
            IUserRepository userRepository
            )
        {
            this.raffleTicketRepository = raffleTicketRepository;
            this.raffleRepository = raffleRepository;
            this.userRepository = userRepository;
        }

        public RaffleTicketVM CreateRaffleTicket(CreateRaffleTicketIM createRafflePrizeIM)
        {
            if (!(createRafflePrizeIM.RaffleId > 0))
            {
                throw new BadRequestException("Raffle is required");
            }
            var raffle = raffleRepository.findById(createRafflePrizeIM.RaffleId);

            if (raffle == null)
            {
                throw new NotFoundException("Raffle is required");
            }

            if(!(createRafflePrizeIM.UserId > 0))
            {
                throw new BadRequestException("User is required");
            }
            bool existsUser = userRepository.ExistsWithId(createRafflePrizeIM.UserId);

            if (!existsUser)
            {
                throw new NotFoundException("User is required");
            }
            //createRafflePrizeIM.RaffleId
            int numTicket = 0;
            try
            {
                numTicket = int.Parse(createRafflePrizeIM.NumTicket);
            }
            catch(Exception e)
            {
                throw new BadRequestException("Num ticket is not valid");
            }

            bool existsTicket = raffleTicketRepository.FindByTicketNumber(createRafflePrizeIM.RaffleId, createRafflePrizeIM.NumTicket);
            if (existsTicket)
            {
                throw new BadRequestException("Num Ticket alread exists");
            }

            RaffleTicketsEntity raffleTicketsEntity = new RaffleTicketsEntity();

            raffleTicketsEntity.RaffleId = createRafflePrizeIM.RaffleId;
            raffleTicketsEntity.UserId = createRafflePrizeIM.UserId;
            raffleTicketsEntity.NumTicket = createRafflePrizeIM.NumTicket;

            raffleTicketsEntity = raffleTicketRepository.createTicket(raffleTicketsEntity);

            return new RaffleTicketVM
            {
                Id = raffleTicketsEntity.Id
            };
        }

        public bool delete(int id)
        {
            throw new NotImplementedException();
        }

        public RaffleTicketVM get(int id)
        {
            RaffleTicketsEntity raffleTicket =  raffleTicketRepository.FindById(id);
            if(raffleTicket == null)
            {
                throw new NotFoundException("Raffle Ticket not found");
            }
            return new RaffleTicketVM
            {
                Id=raffleTicket.Id,
                NumTicket = raffleTicket.NumTicket,
                RaffleId = raffleTicket.RaffleId,
                UserId = raffleTicket.UserId,
            };
        }

        public PagedItems<RaffleTicketVM> ListarPaginado(RaffleTicketPaginationIM query)
        {
            var q = raffleTicketRepository.Query;

            if (query.RaffleId > 0)
            {
                q = q.Where(x => x.RaffleId == query.RaffleId);
            }
            if (query.UserId != null)
            {
                q = q.Where(x => x.UserId == query.UserId);
            }

            var pagedItems = raffleTicketRepository.PaginationQueryRepository<RaffleTicketsEntity>(query, q);
            PagedItems<RaffleTicketVM> response = new PagedItems<RaffleTicketVM>();
            foreach (var item in pagedItems.Items)
            {
                response.Items.Add(new RaffleTicketVM
                {
                    Id = item.Id,
                    NumTicket = item.NumTicket,
                    RaffleId = item.RaffleId,
                    UserId = item.UserId

                });
            }
            response.Total = pagedItems.Total;

            return response;
        }

        public RaffleTicketVM UpdateRaffleTicket(UpdateRaffleTicketIM updateRafflePrizeIM)
        {
            throw new NotImplementedException();
        }
    }
}
