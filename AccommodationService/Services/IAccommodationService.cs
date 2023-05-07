using AccommodationService.Dtos;
using AccommodationService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccommodationService.Services
{
    public interface IAccommodationService
    {
        public Accomodation Edit(string a, string b, int c, string e, string d);
    }
}
