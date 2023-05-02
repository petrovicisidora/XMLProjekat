using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Configuration;
using UserService.Model;
using UserService.Model.dto;
using UserService.Repository;

namespace UserService.Services
{
    public class UserService :IUserService
    {
        private readonly ProjectConfiguration _configuration;

        public UserService(ProjectConfiguration projectConfiguration)
        {
            _configuration = projectConfiguration;
        }

        public IEnumerable<User> GetAll()
        {
            try
            {
                using UnitOfWork unitOfWork = new UnitOfWork(_configuration);

                return unitOfWork.Users.GetAll();
            }
            catch (Exception e) 
            {
                return new List<User>();
            }
        }

       public User Get(long Id)
        {
            try
            {
                using UnitOfWork unitOfWork = new UnitOfWork(_configuration);

                return unitOfWork.Users.Get(Id);
            }
            catch(Exception e)
            {
                return null;
            }
        } 

        public User GetUserWithEmail(string email) 
        {
            try
            {
                using UnitOfWork unitOfWork = new UnitOfWork(_configuration);

                return unitOfWork.Users.GetUserWithEmail(email);

            }
            catch (Exception e) 
            {
                return null;
            }
        }

        public User Delete(long id)
        {
            try
            {
                using UnitOfWork unitOfWork = new UnitOfWork(_configuration);
                User user = unitOfWork.Users.Get(id);


                user.Deleted = true;

                unitOfWork.Users.Update(user);
           

                return user;
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public User Edit(UserDTO userDTO)
        {
            /*   try
               {
                   using UnitOfWork unitOfWork = new UnitOfWork(_configuration);
                   User user = unitOfWork.Users.Get(userDTO.Id);

                   userDTO.Email = user.Email;
                   userDTO.Password = user.Password;
                   userDTO.Name = user.Name;
                   userDTO.Surname = user.Surname;
                   userDTO.PhoneNumber = user.PhoneNumber;
                   userDTO.SSN = user.SSN;


                   unitOfWork.Users.Update(user);


                   return user;
               }
               catch (Exception e)
               {
                   return null;
               }*/
            return null;



        }

        public User Registration(string email, string password, string name, string surname, string city, UserType type)
        {
            try
            {
                if (email == null || password == null || name == null || surname == null || city == null )
                {
                    return null;
                }

                using UnitOfWork unitOfWork = new UnitOfWork(_configuration);

                User user = unitOfWork.Users.GetUserWithEmail(email);

                if (user is not null)
                {
                    return null;
                }

                user = new User();
                user.Email = email;
                user.Password = BCrypt.Net.BCrypt.HashPassword(password);
                user.Name = name;
                user.Surname = surname;
                user.City = city;
                user.UserType = type;
                

                unitOfWork.Users.Add(user);
               
                return user;

            }
            catch (Exception e) 
            {
                return null;
            }

            
            


        }
    }
}
