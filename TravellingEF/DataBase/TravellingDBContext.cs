
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using TravellingCore.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Linq;

namespace TravellingEF.DataBase
{
    public class TravellingDBContext : IdentityDbContext<User>
    {
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<TuristPlace> TuristPLaces { get; set; }
        public DbSet<TuristPlaceCategory> TuristPlaceCategories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }

        public TravellingDBContext()
        {

        }
        public TravellingDBContext(string connectionString) : base(GetOptions(connectionString))
        {

        }
        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }

        public TravellingDBContext(DbContextOptions<TravellingDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
           var cascadeFKs = builder.Model.GetEntityTypes()
                      .SelectMany(t => t.GetForeignKeys())
                      .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;
           

            base.OnModelCreating(builder);
        }

    }
    
}
