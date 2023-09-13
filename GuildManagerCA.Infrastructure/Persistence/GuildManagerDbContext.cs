using GuildManagerCA.Domain.Common.Models.DomainEvents;
using GuildManagerCA.Domain.RaidLocationAggregate;
using GuildManagerCA.Infrastructure.Persistence.Interceptors;
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
        private readonly PublishDomainEventsInterceptor _publishDomainEventsInterceptor;
        public GuildManagerDbContext(DbContextOptions<GuildManagerDbContext> options, PublishDomainEventsInterceptor publishDomainEventsInterceptor) : base(options)
        {
            _publishDomainEventsInterceptor = publishDomainEventsInterceptor;
        }

        public DbSet<RaidLocation> RaidLocations { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Ignore<List<IDomainEvent>>()
                .ApplyConfigurationsFromAssembly(typeof(GuildManagerDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_publishDomainEventsInterceptor);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
