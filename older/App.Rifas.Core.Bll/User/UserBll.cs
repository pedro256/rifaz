using App.Rifas.Core.DataAccess.Entities.Users;
using App.Rifas.Core.DataAccess.Repositories.User;
using App.Rifas.Core.Mapping.Exceptions;
using App.Rifas.Core.Mapping.Filters;
using App.Rifas.Core.Mapping.InputModel.Auth;
using App.Rifas.Core.Mapping.InputModel.User;
using App.Rifas.Core.Mapping.ViewModel;
using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Rifas.Core.Bll.User
{
    public class UserBll : IUserBll
    {
        IUserRepository userRep;

        public UserBll(
            IUserRepository userRepository
            )
        {
            userRep = userRepository;
        }
        private void validExistEmail(string email)
        {
            bool existsEmail = userRep.existUserWithEmail(email);
            if (existsEmail)
            {
                throw new BadRequestException("Email already exists.");
            }
        }
        private void validCreationUserInput(UserIM user)
        {

            if (user.Name == null)
            {
                throw new BadRequestException("Name is required.");
            }
            if (user.Email == null)
            {
                throw new BadRequestException("Email is required.");
            }
            else
            {
                validExistEmail(user.Email);
            }
            if (user.Password == null)
            {
                throw new BadRequestException("Password is required.");
            }
            else if (user.Password.Length < 6)
            {
                throw new BadRequestException("Password must be more than 6 characters.");
            }
            /*
            if (user.BirthDate == null)
            {
                throw new BadRequestException("BirthDate is required.");
            }
            */
        }
        public UserVM createUser(UserIM user)
        {
            validCreationUserInput(user);
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);


            UserEntity userEntity = new UserEntity()
            {
                Name = user.Name,
                Email = user.Email,
                Password = passwordHash,
                BirthDate = (DateTime)user.BirthDate
            };

            userEntity = userRep.Salvar(userEntity);
            userRep.Context.SaveChanges();


            user.Id = userEntity.Id;
            return new UserVM
            {
                Id = userEntity.Id,
                BirthDate = userEntity.BirthDate,
                Email = userEntity.Email,
                Name = userEntity.Name
            };
        }

        public UserVM updateUser(UserIM user)
        {
            if (user.Id <=0)
            {
                throw new BadRequestException("Id is Required.");
            }
            UserEntity ett = userRep.Selecionar(x=>x.Id == user.Id);

            if(ett == null)
            {
                throw new BadRequestException("Entity not found.");
            }

            if (user.Name != null && String.IsNullOrEmpty(user.Name))
            {
                ett.Name = user.Name;
            }
            if(user.Email != null && String.IsNullOrEmpty(user.Email))
            {
                validExistEmail(user.Email);
                ett.Email = user.Email;
            }
            if(user.BirthDate != null && DateTime.MinValue != user.BirthDate)
            {
                ett.BirthDate = (DateTime)user.BirthDate;
            }

            userRep.Update(ett);
            userRep.Context.SaveChanges();

            return new UserVM
            {
                Id = (int)user.Id
            };
        }

        public PagedItems<UserVM> ListarPaginado(UserPaginationIM input)
        {
            var query = userRep.Query;

            if (input.Name != null)
            {
                query = query.Where(x => x.Name.Contains(input.Name));
            }
            if(input.Email != null)
            {
                query = query.Where(x=>x.Email.Contains(input.Email));
            }

            var pagedItems =  userRep.PaginationQueryRepository<UserEntity>(input, query);
            PagedItems<UserVM> response = new PagedItems<UserVM>();
            foreach(var item in pagedItems.Items)
            {
                response.Items.Add(new UserVM
                {
                    Id = item.Id,
                    Name = item.Name,
                    Email = item.Email,
                    BirthDate = item.BirthDate
                });
            }
            response.Total = pagedItems.Total;

            return response;

        }

        public UserVM getUser(int id)
        {
            UserEntity ett = userRep.Selecionar(x=>x.Id == id);
            if(ett == null)
            {
                throw new NotFoundException("User not found.");
            }
            var user = new UserVM
            {
                Id = ett.Id,
                Name = ett.Name,
                Email = ett.Email,
                BirthDate = ett.BirthDate
            };

            return user;
        }
        public bool deleteUser(int id)
        {
            UserEntity ett = userRep.Selecionar(x => x.Id == id);
            if (ett == null)
            {
                throw new NotFoundException("User not found.");
            }
            userRep.deleteUser(ett);

            return true;
        }

        public bool validUserAuthentication(AuthIM auth)
        {

            UserEntity user = userRep.Selecionar(x => x.Email == auth.Username);

            if(user == null)
            {
                throw new NotFoundException("User not found !");
            }

            bool isValid = BCrypt.Net.BCrypt.Verify(auth.Password, user.Password);

            if (!isValid)
            {
                return false;
            }
            return true;
        }
    }
}
