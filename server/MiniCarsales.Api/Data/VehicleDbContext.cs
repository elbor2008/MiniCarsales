using Microsoft.EntityFrameworkCore;
using MiniCarsales.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MiniCarsales.Api.Data
{
    public class VehicleDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        public VehicleDbContext(DbContextOptions<VehicleDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
