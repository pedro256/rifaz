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
            _context.UserEntity.Add(user);
            _context.SaveChanges();
            return user;
        }

        public void deleteUser(UserEntity entity)
        {
            _context.UserEntity.Attach(entity);
            _context.UserEntity.Remove(entity);
            _context.SaveChanges();

        }

        public bool existUserWithEmail(string email)
        {
            int counter = _context.UserEntity.Count(x => x.Email == email) ;
            if (counter > 0)
            {
                return true;
            }
            return false;
        }
    }
}
