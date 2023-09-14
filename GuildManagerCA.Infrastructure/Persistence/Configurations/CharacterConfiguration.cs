using GuildManagerCA.Domain.CharacterAggregate;
using GuildManagerCA.Domain.CharacterAggregate.ValueObjects;
using GuildManagerCA.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Infrastructure.Persistence.Configurations
{
    public class CharacterConfiguration : IEntityTypeConfiguration<Character>
    {
        public void Configure(EntityTypeBuilder<Character> builder)
        {
            builder.ToTable("Characters");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasColumnName("CharacterId")
                .HasConversion(
                id => id.Value,
                value => CharacterId.Create(value));

            builder.Property(x => x.UserId)
                .HasConversion(
                id => id.Value,
                value => UserId.Create(value)
                );

            builder.Property(x => x.Name)
                .HasMaxLength(20);

            builder.OwnsMany(x => x.SpecializationIds, sb =>
            {
                sb.ToTable("CharacterSpecializationIds");

                sb.WithOwner().HasForeignKey("CharacterId");
                sb.HasKey("Id");
                sb.Property(specId => specId.Value)
                .HasColumnName("SpecializationId");

            });

            builder.Metadata.FindNavigation(nameof(Character.SpecializationIds))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.OwnsMany(x => x.RaidEventIds, eb =>
            {
                eb.ToTable("CharacterRaidEventIds");

                eb.WithOwner().HasForeignKey("CharacterId");
                eb.HasKey("Id");
                eb.Property(eventId => eventId.Value)
                .HasColumnName("RaidEventId");
            });

            builder.Metadata.FindNavigation(nameof(Character.RaidEventIds))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
                
        }
    }
}
