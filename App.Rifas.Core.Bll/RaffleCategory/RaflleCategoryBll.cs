using App.Rifas.Core.Bll.RaffleCategory;
using App.Rifas.Core.DataAccess.Entities.CategoriesRaflleTicket;
using App.Rifas.Core.DataAccess.Entities.Raffle;
using App.Rifas.Core.DataAccess.Entities.Users;
using App.Rifas.Core.DataAccess.Repositories.RaffleCategory;
using App.Rifas.Core.Mapping.Exceptions;
using App.Rifas.Core.Mapping.Filters;
using App.Rifas.Core.Mapping.InputModel;
using App.Rifas.Core.Mapping.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Rifas.Core.Bll.RaffleCategory
{
    public class RaflleCategoryBll: IRaffleCategoryBll
    {
        IRaffleCategoryRepository raffleCategoryRep;
        public RaflleCategoryBll(
            IRaffleCategoryRepository _raffleCategoryRep
            )
        {
            raffleCategoryRep = _raffleCategoryRep; 
        }

        public RaffleCategoryVM create(RaffleCategoryVM category)
        {
            if (category.Name.Length < 1)
            {
                throw new BadRequestException("Name is required.");
            }

            CategoriesRaflleEntity ett = new CategoriesRaflleEntity();
            ett.Name = category.Name;
            ett.Description=  category.Description;

            ett = raffleCategoryRep.createCategory(ett);

            category.Id = ett.Id;

            return category;
        }

        public bool delete(int id)
        {
            
            var ett = raffleCategoryRep.FindById(id);
            if (ett==null)
            {
                throw new NotFoundException("Category don´t exists");
            }
            raffleCategoryRep.deleteCategory(ett);

            return true;    
        }

        public RaffleCategoryVM get(int id)
        {
            throw new NotImplementedException();
        }

        public PagedItems<RaffleCategoryVM> ListarPaginado(RaffleCategoryPaginationQueryVM category)
        {
            var query = raffleCategoryRep.Query;

            if (category.Name != null)
            {
                query = query.Where(x => x.Name.Contains(category.Name));
            }
            if (category.Description != null)
            {
                query = query.Where(x => x.Description.Contains(category.Description));
            }

            var pagedItems = raffleCategoryRep.PaginationQueryRepository<CategoriesRaflleEntity>(category, query);
            PagedItems<RaffleCategoryVM> response = new PagedItems<RaffleCategoryVM>();
            foreach (var item in pagedItems.Items)
            {
                response.Items.Add(new RaffleCategoryVM
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description

                });
            }
            response.Total = pagedItems.Total;

            return response;
        }

        public RaffleCategoryVM update(RaffleCategoryVM category)
        {
            if (category.Id == null)
            {
                throw new BadRequestException("Id is required.");
            }
            CategoriesRaflleEntity ett = raffleCategoryRep.FindById((int)category.Id);

            if (ett == null)
            {
                throw new NotFoundException("Category don´t exist.");
            }

            if (category.Name.Length < 1)
            {
                throw new BadRequestException("Name is required.");
            }

            ett.Name = category.Name;
            ett.Description = category.Description;

            raffleCategoryRep.updateCategory(ett);

            return category;
        }
    }
}
