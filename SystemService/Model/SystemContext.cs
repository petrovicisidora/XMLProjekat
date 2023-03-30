using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemService.Configuration;

namespace SystemService.Model
{
    public class SystemContext : DbContext
    {
        private static ProjectConfiguration _configuration;

        public SystemContext(DbContextOptions<SystemContext> options, ProjectConfiguration configuration) : base(options)
        {
            if (configuration != null)
            {
                _configuration = configuration;
            }
        }

        public SystemContext()
        {

        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Reservations> Reservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer("Server=mssql;Database=system;User=sa;Password=A&VeryComplex123Password");
        }

    }
}
