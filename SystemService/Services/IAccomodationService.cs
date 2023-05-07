using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemService.Services
{
    public interface IAccomodationService
    {
        Task<AccomodationResponse> GetAccomodationById(string id);
    }
}
