using Coworking.Api.DataAcces.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coworking.Api.DataAcces
{
    public class CoworkingDBContext : DbContext, ICoworkingDBContext
    {
        public CoworkingDBContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { 
        
        }
    }
}
