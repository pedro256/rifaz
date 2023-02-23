using App.Rifas.Core.DataAccess.Entities.CategoriesRaflleTicket;
using App.Rifas.Core.DataAccess.Entities.RafflePrize;
using App.Rifas.Core.DataAccess.Repositories.Raffle;
using App.Rifas.Core.DataAccess.Repositories.RafflePrize;
using App.Rifas.Core.Mapping.Exceptions;
using App.Rifas.Core.Mapping.Filters;
using App.Rifas.Core.Mapping.InputModel.RafflePrize;
using App.Rifas.Core.Mapping.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Rifas.Core.Bll.RafflePrize
{
    public class RafflePrizeBll : IRafflePrizeBll
    {
        IRafflePrizeRepository rafflePrizeRepository;
        IRaffleRepository raffleRepository;

        public RafflePrizeBll(
            IRafflePrizeRepository rafflePrizeRepository,
            IRaffleRepository raffleRepository
            )
        {
            this.rafflePrizeRepository = rafflePrizeRepository;
            this.raffleRepository = raffleRepository;
        }   

        public RafflePrizeVM CreateRafflePrize(CreateRafflePrizeIM createRafflePrizeIM)
        {
            if(!(createRafflePrizeIM.RaffleId >0))
            {
                throw new BadRequestException("RaffleId is required.");
            }
            int counter =  raffleRepository.Count(r => r.Id == createRafflePrizeIM.RaffleId);
            if (counter !=1)
            {
                throw new NotFoundException("RaffleId not found.");
            }

            if (createRafflePrizeIM.Name.Length < 4)
            {
                throw new BadRequestException("Name should have more that 3 caracteres.");
            }

            RafflePrizeEntity rafflePrizeEntity = new RafflePrizeEntity();
            rafflePrizeEntity.RaffleId = createRafflePrizeIM.RaffleId;
            rafflePrizeEntity.Name = createRafflePrizeIM.Name;
            rafflePrizeEntity.Description = createRafflePrizeIM.Description;
            rafflePrizeEntity.Position = createRafflePrizeIM.Position;

            rafflePrizeEntity = rafflePrizeRepository.createRPrize(rafflePrizeEntity);

            return new RafflePrizeVM
            {
                Id = rafflePrizeEntity.Id
            };
        }

        public bool delete(int id)
        {
            var it = rafflePrizeRepository.FindById(id);
            if (it == null)
            {
                throw new NotFoundException("Not found.");
            }

            rafflePrizeRepository.deleteRPrize(it);
            return true;
        }

        public RafflePrizeVM get(int id)
        {
            var q = rafflePrizeRepository.Query;

            q = q.Include(x => x.Winner);
            q = q.Include(x => x.Raffle);
            q = q.Where(r => r.Id == id);

            var it = q.AsNoTracking().FirstOrDefault();

            if (it == null)
            {
                throw new NotFoundException("Not found.");
            }
            return new RafflePrizeVM
            {
                Id = it.Id,
                Description = it.Description,
                Name = it.Name,
                Position = it.Position,
                RaffleId = it.RaffleId,
                WinnerId = it.WinnerId,
                //Winner = it.Winner
            };
        }

        public PagedItems<RafflePrizeVM> ListarPaginado(RafflePrizePaginationIM query)
        {
            var q = rafflePrizeRepository.Query;

            var pagedItems = rafflePrizeRepository.PaginationQueryRepository<RafflePrizeEntity>(query, q);
            PagedItems<RafflePrizeVM> response = new PagedItems<RafflePrizeVM>();
            foreach (var item in pagedItems.Items)
            {
                response.Items.Add(new RafflePrizeVM
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Position = item.Position,
                    //WinnerId = (int)item.WinnerId,
                    RaffleId=item.RaffleId,

                });
            }
            response.Total = pagedItems.Total;

            return response;
        }

        public RafflePrizeVM UpdateRafflePrize(UpdateRafflePrizeIM updateRafflePrizeIM)
        {
            throw new NotImplementedException();
        }
    }
}
