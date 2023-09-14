using GuildManagerCA.Domain.SpecializationAggregate;
using GuildManagerCA.Domain.SpecializationAggregate.ValueObjects;
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
    public class SpecializationConfiguration : IEntityTypeConfiguration<Specialization>
    {
        public void Configure(EntityTypeBuilder<Specialization> builder)
        {
            builder.ToTable("Specializations");

            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id)
                .ValueGeneratedNever()
                .HasColumnName("SpecializationId")
                .HasConversion(
                id => id.Value,
                value => SpecializationId.Create(value));

            builder.Property(s => s.Name)
                .HasMaxLength(50);

            builder.OwnsOne(s => s.CharacterClass, cb =>
            {
                cb.Property(c => c.Name)
                .HasColumnName("ClassName")
                .HasMaxLength(30);

                cb.Property(cb => cb.ImageUrl)
                .HasColumnName("ClassImageUrl")
                .HasMaxLength(100)
                .HasUriConversion();
            });

            builder.Property(s => s.ImageUrl)
                .HasUriConversion();
        }
    }
}
