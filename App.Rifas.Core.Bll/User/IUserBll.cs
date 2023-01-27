using App.Rifas.Core.Mapping.Filters;
using App.Rifas.Core.Mapping.InputModel;
using App.Rifas.Core.Mapping.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Rifas.Core.Bll.User
{
    public interface IUserBll
    {
        //void validCreationUserInput(UserIM user);
        UserVM createUser(UserIM user);
        UserVM updateUser(UserIM user);
        UserVM getUser(int id);
        bool deleteUser(int id);
        PagedItems<UserVM> ListarPaginado(UserPaginationIM userVM);
        
    }
}
