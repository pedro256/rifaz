using App.Rifas.Core.Bll.RaffleCategory;
using App.Rifas.Core.DataAccess.Entities.CategoriesRaflleTicket;
using App.Rifas.Core.DataAccess.Entities.Raffle;
using App.Rifas.Core.DataAccess.Repositories.Raffle;
using App.Rifas.Core.DataAccess.Repositories.RaffleCategory;
using App.Rifas.Core.DataAccess.Repositories.User;
using App.Rifas.Core.Mapping.Exceptions;
using App.Rifas.Core.Mapping.Filters;
using App.Rifas.Core.Mapping.InputModel.Raffle;
using App.Rifas.Core.Mapping.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Rifas.Core.Bll.Raffle
{
    public class RaffleBll : IRaffleBll
    {
        IRaffleRepository repository;
        IRaffleCategoryRepository raffleCategoryRepo;
        IUserRepository userRepository;

        public RaffleBll(
            IRaffleRepository repository,
            IRaffleCategoryRepository _raffleCategoryRepository,
            IUserRepository _userRepository
            )
        {
            this.repository = repository;
            raffleCategoryRepo = _raffleCategoryRepository;
            userRepository = _userRepository;
        }

        private string CreateProtocolRaffle()
        {
            string protocol = "";
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            const int length = 8;
            Random random = new Random();
            
            for(int i = 0; i < 4; i++)
            {
                protocol += new string(
                    Enumerable.Repeat(chars, length)
                    .Select(s => s[random.Next(s.Length)])
                    .ToArray()
                    );
                if(i < 3)
                {
                    protocol += ".";
                }
            }

            return protocol;
        }

        public RaffleVM create(CreateRaffleIM raffle)
        {
            RaffleEntity raffleEntity = new RaffleEntity();

            raffleEntity.Title = raffle.Title;
            raffleEntity.Description = raffle.Description;


            if (!userRepository.ExistsWithId(raffle.OwnerId))
            {
                throw new NotFoundException("User not found.");
            }
            if (!raffleCategoryRepo.ExistsWithId(raffle.CategoryId))
            {
                throw new NotFoundException("Category not found.");
            }


            raffleEntity.OwnerId = raffle.OwnerId;
            raffleEntity.CategoryId = raffle.CategoryId;
            raffleEntity.Protocol = CreateProtocolRaffle();

            repository.CreateRaffle(raffleEntity);

            return new RaffleVM
            {
                Id = raffleEntity.Id,
                CategoryId = raffleEntity.CategoryId,
                Description = raffleEntity.Description,
                OwnerId = raffleEntity.OwnerId,
                Protocol = raffleEntity.Protocol,
                Title = raffleEntity.Title
            };
        }


        public bool delete(int id)
        {
            throw new NotImplementedException();
        }

        public RaffleVM get(int id)
        {
            RaffleEntity raffle = repository.findById(id);
            if (raffle == null)
            {
                throw new NotFoundException("Raffle not found.");
            }
            return new RaffleVM
            {
                Id = raffle.Id,
                CategoryId = raffle.CategoryId,
                Description = raffle.Description,
                OwnerId = raffle.OwnerId,
                Title = raffle.Title
            };
        }

        public PagedItems<RaffleVM> ListarPaginado(RafflePaginationIM filter)
        {

            var query = repository.Query;

            if(filter.OwnerId > 0)
            {
                query = query.Where(x => x.OwnerId == filter.OwnerId);
            }
            if (filter.CategoryId > 0)
            {
                query = query.Where(x => x.CategoryId == filter.CategoryId);
            }
            if(filter.Description?.Length>0)
            {
                query = query.Where(x => x.Description.Contains(filter.Description));
            }
            if (filter.Title?.Length > 0)
            {
                query = query.Where(x=> x.Title.Contains(filter.Title));
            }

            var listEntity = repository.PaginationQueryRepository<RaffleEntity>(filter, query);
            PagedItems<RaffleVM> response = new PagedItems<RaffleVM>();
            response.Total = listEntity.Total;

            foreach(var item in listEntity.Items)
            {
                response.Items.Add(new RaffleVM
                {
                    Id = item.Id,
                    CategoryId = item.CategoryId,
                    Description = item.Description,
                    OwnerId = item.OwnerId,
                    Protocol = item.Protocol,
                    Title = item.Title
                });
            }

            return response;
        }

        public RaffleVM update(UpdateRaffleIM raffle)
        {
            throw new NotImplementedException();
        }
    }
}
