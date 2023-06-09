﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Configuration;
using UserService.Model;
using UserService.Model.dto;
using UserService.Repository;

namespace UserService.Services
{
    public class UserService : BaseService<User>, IUserService
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
                using UnitOfWork unitOfWork = new UnitOfWork(new UserContext());

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
                using UnitOfWork unitOfWork = new UnitOfWork(new UserContext());

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
                using UnitOfWork unitOfWork = new UnitOfWork(new UserContext());

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
                using UnitOfWork unitOfWork = new UnitOfWork(new UserContext());
                User user = unitOfWork.Users.Get(id);


                user.Deleted = true;

                unitOfWork.Users.Update(user);
                unitOfWork.Complete();

                return user;
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public User Edit(UserDTO userDTO)
        {
            try
            {
                using UnitOfWork unitOfWork = new UnitOfWork(new UserContext());
                User user = unitOfWork.Users.Get(userDTO.Id);

                userDTO.Email = user.Email;
                userDTO.Password = user.Password;
                userDTO.Name = user.Name;
                userDTO.Surname = user.Surname;
                userDTO.PhoneNumber = user.PhoneNumber;
                userDTO.SSN = user.SSN;
               

                unitOfWork.Users.Update(user);
                unitOfWork.Complete();

                return user;
            }
            catch (Exception e)
            {
                return null;
            }


        }

        public User Registration(string email, string password, string name, string surname, string ssn, string phoneNumber)
        {
            try
            {
                if (email == null || password == null || name == null || surname == null || phoneNumber == null || ssn == null)
                {
                    return null;
                }

                using UnitOfWork unitOfWork = new UnitOfWork(new UserContext());

                User user = unitOfWork.Users.GetUserWithEmail(email);

                if (user is not null)
                {
                    return null;
                }

                user = new User();
                user.Email = email;
                user.Password = password;
                user.Name = name;
                user.Surname = surname;
                user.PhoneNumber = phoneNumber;
                user.SSN = ssn;
                

                unitOfWork.Users.Add(user);
                unitOfWork.Complete();

                return user;

            }
            catch (Exception e) 
            {
                return null;
            }

            
            


        }
    }
}
