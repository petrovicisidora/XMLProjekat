using AccomodationService;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;
using UserService.Configuration;
using UserService.Model;
using UserService.Model.dto;
using UserService.Repository;
using Grpc.Net.Client;
using Grpc.Core;
using MongoDB.Driver;

namespace UserService.Services
{
    public class UserService : IUserService
    {
        private readonly ProjectConfiguration _configuration;
        private readonly UserRepository _userRepository;

        public UserService(ProjectConfiguration projectConfiguration)
        {
            _configuration = projectConfiguration;
            _userRepository = new UserRepository(_configuration);
        }

        public IEnumerable<User> GetAll()
        {
            try
            {
                string id = "645a8e278d674fcd9999e34a";
                var channel = new Grpc.Core.Channel("localhost", 4112, ChannelCredentials.Insecure);
                var client = new AccommodationGrpc.AccommodationGrpcClient(channel);
                var accommodation = client.GetAccommodationInfo(new AccommodationRequest { Id = id });


                using UnitOfWork unitOfWork = new UnitOfWork(_configuration);

                return unitOfWork.Users.GetAll();
            }
            catch (Exception e) 
            {
                return null;
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
                //string id = "645a8e278d674fcd9999e34a";
                //var channel = new Grpc.Core.Channel("localhost", 4112, ChannelCredentials.Insecure);
                //var client = new AccommodationGrpc.AccommodationGrpcClient(channel);
                //var accommodation = client.GetAccommodationInfo(new AccommodationRequest { Id = id });

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

        public void Update(User user)
        {
            using UnitOfWork unitOfWork = new UnitOfWork(_configuration);
            unitOfWork.Users.Update(user);

        }

        public User Registration(string email, string password, string name, string surname, string city, string type)
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
                if (type == "G")
                {
                    user.UserType = UserType.G;
                }
                else
                {
                    user.UserType = UserType.H;
                }
              
                

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
