using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemService.Core;
using SystemService.Model;

namespace SystemService.Repository
{
    public class CityRepository : BaseRepository<City>, ICityRepository
    {
        public CityRepository(SystemContext context) : base(context)
        {

        }
    }
}
