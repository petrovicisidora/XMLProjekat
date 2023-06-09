﻿using AccommodationService.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccommodationService.Model
{
    public class AccommodationContext : DbContext
    {
        private static ProjectConfiguration _configuration;
        
        public AccommodationContext(DbContextOptions<AccommodationContext> options, ProjectConfiguration configuration) : base(options)
        {
            if(configuration != null)
            {
                _configuration = configuration;
            }
        }

        public AccommodationContext()
        {

        }

        public DbSet<Accomodation> Accommodations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder) 
        {
            optionBuilder.UseSqlServer("Data Source=mssql,1433;Initial Catalog=accommodation;User ID=sa;Password=A&VeryComplex123Password");
        }

    }
}
