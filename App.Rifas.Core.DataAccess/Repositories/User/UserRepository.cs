using App.Rifas.Core.DataAccess.Context;
using App.Rifas.Core.DataAccess.Entities.Users;
using App.Rifas.Core.DataAccess.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Rifas.Core.DataAccess.Repositories.User
{
    public class UserRepository : GenericRepository<UserEntity>, IUserRepository
    {

        public UserRepository(RifazDBContext context) : base(context)
        {

        }

        public UserEntity createUser(UserEntity user)
        {
            Context.UserEntity.Add(user);
            Context.SaveChanges();
            return user;
        }

        public void deleteUser(UserEntity entity)
        {
            Context.UserEntity.Attach(entity);
            Context.UserEntity.Remove(entity);
            Context.SaveChanges();

        }
        public bool ExistsWithId(int Id)
        {
            int counter = Context.UserEntity.Count(x => x.Id == Id);
            if (counter > 0)
            {
                return true;
            }
            return false;
        }
        public bool existUserWithEmail(string email)
        {
            int counter = Context.UserEntity.Count(x => x.Email == email) ;
            if (counter > 0)
            {
                return true;
            }
            return false;
        }
    }
}
