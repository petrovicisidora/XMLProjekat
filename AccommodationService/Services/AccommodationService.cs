using AccommodationService.Configuration;
using AccommodationService.Dtos;
using AccommodationService.Model;
using AccommodationService.Repositroy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AccommodationService.Services
{
    public class AccommodationService : IAccommodationService
    {
        private readonly ProjectConfiguration _configuration;
        private readonly IWebHostEnvironment env;

        public AccommodationService(ProjectConfiguration projectConfiguration, IWebHostEnvironment env)
        {
            _configuration = projectConfiguration;
            this.env = env;
        }

        public async Task<Accomodation> Create(AccomodationDto dto)
        {
            List<byte[]> listt = new List<byte[]>();
            foreach(IFormFile f in dto.Image) {
                if (dto.Image != null && f.Length > 0)
                {
                   
                    using (var ms= new MemoryStream())
                    {
                        f.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        listt.Add(fileBytes);
                    }
                }
            }
            try
            {
                using UnitOfWork unitOfWork = new UnitOfWork(_configuration);

                Accomodation acc = new()
                {
                    Price = dto.Price,
                    FreeParking = dto.FreeParking,
                    Location = dto.Location,
                    MaxCapacity = dto.MaxCapacity,
                    MinCapacity = dto.MinCapacity,
                    Name = dto.Name,
                    WifiIncluded = dto.WifiIncluded,
                    AcInclude = dto.AcInclude,
                    ImagePath = listt
                };

                unitOfWork.Accommodations.Add(acc);
                return acc;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public Accomodation Edit(string a, string b, int c, string e, string d)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Accomodation> GetAll()
        {
            try
            {
                using UnitOfWork unitOfWork = new UnitOfWork(_configuration);
                IEnumerable<Accomodation> accs = unitOfWork.Accommodations.GetAll();
                return accs;
            }
            catch(Exception e)
            {
                return null;
            }

        }

        public List<Accomodation> PretraziSmestaj(string lokacija, int brojGostiju, DateTime pocetakPutovanja, DateTime krajPutovanja)
        {
            using UnitOfWork unitOfWork = new UnitOfWork(_configuration);
            var smestaji = unitOfWork.Accommodations.GetAll().Where(s => s.Location.City == lokacija && s.MinCapacity <= brojGostiju && s.MaxCapacity >= brojGostiju).ToList();

            foreach (var smestaj in smestaji)
            {
                // Izračunaj ukupnu cenu smeštaja za sva noćenja
                var brojNocenja = (krajPutovanja - pocetakPutovanja).Days;
                var ukupnaCena = smestaj.Price * brojNocenja;

                // Izračunaj jediničnu cenu
                decimal jedinicnaCena;
                if (smestaj.MaxCapacity == 1)
                {
                    jedinicnaCena = smestaj.Price;
                }
                else
                {
                    jedinicnaCena = ukupnaCena / (decimal)brojNocenja / smestaj.MaxCapacity;
                }

                // Dodaj informacije o ceni smeštaja
                smestaj.Availability = $"Ukupna cena: {ukupnaCena}, Jedinična cena: {jedinicnaCena}/noćenju";
            }

            return smestaji;
        }


        /*     public Accomodation Edit(string cITYid, string name, int price, string capapcity, string ava)
             {
            try
             {
                 using UnitOfWork unitOfWork = new UnitOfWork(_configuration);

                 Accomodation acc = new Accomodation();
                 //acc.Capacity = capapcity;
                 acc.Availability = ava;
                 acc.Name = name;
                 acc.Price = price;
                 //acc.CityID = cITYid;
                 unitOfWork.Accommodations.Add(acc);
                 return acc;
             }
             catch (Exception e)
             {
                 Console.WriteLine(e);
                 return null;
             }

         }
              */
    }
}
