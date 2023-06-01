using Applications.DB.Entities;
using Applications.DB.Shema;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.DB
{
    public class CarPollDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Metro> Metro { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Trip> Trips { get; set; }


        public CarPollDbContext(DbContextOptions<CarPollDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntitySchemaDefinition());
            modelBuilder.ApplyConfiguration(new DayEntitySchemaDefinition());
            modelBuilder.ApplyConfiguration(new DestinationEntitySchemaDefinition());
            modelBuilder.ApplyConfiguration(new MetroEntitySchemaDefinition());
            modelBuilder.ApplyConfiguration(new ReviewEntitySchemaDefinition());
            modelBuilder.ApplyConfiguration(new RoleEntitySchemaDefinition());
            modelBuilder.ApplyConfiguration(new ScoreEntitySchemaDefinition());
            modelBuilder.ApplyConfiguration(new StatusEntitySchemaDefinition());
            modelBuilder.ApplyConfiguration(new TripEntitySchemaDefinition());
            base.OnModelCreating(modelBuilder);
        }
    }
}
