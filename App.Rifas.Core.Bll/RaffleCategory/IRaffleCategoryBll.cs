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
    public interface IRaffleCategoryBll
    {
        RaffleCategoryVM create(RaffleCategoryVM category);
        RaffleCategoryVM update(RaffleCategoryVM category);
        RaffleCategoryVM get(int id);
        bool delete(int id);
        PagedItems<RaffleCategoryVM> ListarPaginado(RaffleCategoryPaginationQueryVM query);

    }
}
