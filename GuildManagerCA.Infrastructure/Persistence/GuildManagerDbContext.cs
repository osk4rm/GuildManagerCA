using GuildManagerCA.Domain.RaidLocationAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Infrastructure.Persistence
{
    public class GuildManagerDbContext : DbContext
    {
        public GuildManagerDbContext(DbContextOptions<GuildManagerDbContext> options) : base(options)
        {
            
        }

        public DbSet<RaidLocation> RaidLocations { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GuildManagerDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
