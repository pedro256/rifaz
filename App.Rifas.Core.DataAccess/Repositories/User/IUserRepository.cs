using App.Rifas.Core.DataAccess.Entities.Users;
using App.Rifas.Core.DataAccess.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Rifas.Core.DataAccess.Repositories.User
{
    public interface IUserRepository : IGenericRepository<UserEntity>
    {
        UserEntity createUser(UserEntity user);

        void deleteUser(UserEntity user);

        bool existUserWithEmail(string email);
    }
}
