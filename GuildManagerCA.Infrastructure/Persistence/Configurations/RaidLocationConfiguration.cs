using GuildManagerCA.Domain.RaidLocationAggregate;
using GuildManagerCA.Domain.RaidLocationAggregate.ValueObjects;
using GuildManagerCA.Infrastructure.Persistence.EFUtils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Infrastructure.Persistence.Configurations
{
    public class RaidLocationConfiguration : IEntityTypeConfiguration<RaidLocation>
    {
        public void Configure(EntityTypeBuilder<RaidLocation> builder)
        {
            builder.ToTable("RaidLocations");

            //key config
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value, value => RaidLocationId.Create(value));

            //properties config
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.OwnsOne(e => e.Expansion, eb =>
            {
                eb.Property(x => x.Name).IsRequired()
                .HasColumnName("ExpansionName")
                .HasMaxLength(100);

                eb.Property(x => x.ImageUrl)
                .HasUriConversion()
                .HasColumnName("ExpansionImageUrl")
                .HasMaxLength(100);
            });


            builder.Property(e => e.ImageUrl)
                .IsRequired()
                .HasUriConversion();
        }
    }

}
