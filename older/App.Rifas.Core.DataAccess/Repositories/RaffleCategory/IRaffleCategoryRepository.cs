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
    public interface IRaffleCategoryRepository : IGenericRepository<CategoriesRaflleEntity>
    {
        CategoriesRaflleEntity createCategory(CategoriesRaflleEntity category);
        CategoriesRaflleEntity updateCategory(CategoriesRaflleEntity category);
        void deleteCategory(CategoriesRaflleEntity category);
        bool ExistsWithId(int Id);
        CategoriesRaflleEntity FindById(int Id);
}
}
