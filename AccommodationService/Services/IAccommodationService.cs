using AccommodationService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccommodationService.Services
{
    public interface IAccommodationService
    {
        public Accomodation Edit(string a, string b, string c, string e, string d);
    }
}
