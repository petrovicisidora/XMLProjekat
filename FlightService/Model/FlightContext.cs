using FlightService.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightService.Model
{
    public class FlightContext : DbContext
    {
        private static ProjectConfiguration _configuration;

        public FlightContext(DbContextOptions<FlightContext> options, ProjectConfiguration configuration) : base(options)
        {
            if (configuration != null)
            {
                _configuration = configuration;
            }
        }

        public FlightContext()
        {

        }

    }
}
