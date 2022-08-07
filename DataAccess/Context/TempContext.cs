using DataAccess.Configuration;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class TempContext : DbContext
    {
        public TempContext(DbContextOptions<TempContext> options) : base(options)
        {
        }

        // DbSet properties
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ApplyConfigurations
            modelBuilder.ApplyConfiguration(new UserConfig());
        }
    }
}
