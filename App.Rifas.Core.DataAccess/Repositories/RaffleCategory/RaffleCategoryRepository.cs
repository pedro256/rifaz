using App.Rifas.Core.DataAccess.Context;
using App.Rifas.Core.DataAccess.Entities.CategoriesRaflleTicket;
using App.Rifas.Core.DataAccess.Entities.Users;
using App.Rifas.Core.DataAccess.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Rifas.Core.DataAccess.Repositories.RaffleCategory
{
    public class RaffleCategoryRepository : GenericRepository<CategoriesRaflleEntity>, IRaffleCategoryRepository
    {
        public RaffleCategoryRepository(RifazDBContext context) : base(context)
        {

        }
        public CategoriesRaflleEntity createCategory(CategoriesRaflleEntity category)
        {
            Context.CategoriesRaflleEntity.Add(category);
            Context.SaveChanges();
            return category;
        }

        public void deleteCategory(CategoriesRaflleEntity category)
        {
            Context.CategoriesRaflleEntity.Attach(category);
            Context.CategoriesRaflleEntity.Remove(category);
            Context.SaveChanges();
        }

        public CategoriesRaflleEntity updateCategory(CategoriesRaflleEntity category)
        {
            Context.CategoriesRaflleEntity.Update(category);
            Context.SaveChanges();
            return category;
        }

        public CategoriesRaflleEntity FindById(int Id)
        {
            var response = Context.CategoriesRaflleEntity.Find(Id);
            return response;
        }

        public bool ExistsWithId(int Id)
        {
            int counter = Context.CategoriesRaflleEntity.Count(x => x.Id == Id);
            if (counter > 0)
            {
                return true;
            }
            return false;
        }
    }
}
