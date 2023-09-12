using GuildManagerCA.Domain.CharacterAggregate.ValueObjects;
using GuildManagerCA.Domain.RaidEventAggregate;
using GuildManagerCA.Domain.RaidEventAggregate.ValueObjects;
using GuildManagerCA.Domain.RaidLocationAggregate.ValueObjects;
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
    public class RaidEventConfiguration : IEntityTypeConfiguration<RaidEvent>
    {
        public void Configure(EntityTypeBuilder<RaidEvent> builder)
        {
            ConfigureRaidEventsTable(builder);
            ConfigureCommentsTable(builder);
            ConfigureAttendances(builder);
        }

        

        private static void ConfigureRaidEventsTable(EntityTypeBuilder<RaidEvent> builder)
        {
            builder.ToTable("RaidEvents");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasConversion(
                id => id.Value,
                value => RaidEventId.Create(value));

            //TODO: other properties config
            builder.Property(e => e.RaidLocationId)
                .HasConversion(
                id => id.Value,
                value => RaidLocationId.Create(value));

            builder.Property(e => e.HostId)
                .HasConversion(
                id => id.Value,
                value => UserId.Create(value)
                );

            builder.Metadata.FindNavigation(nameof(RaidEvent.Comments))!
                .SetPropertyAccessMode(PropertyAccessMode.Property);
            builder.Metadata.FindNavigation(nameof(RaidEvent.Attendances))!
                .SetPropertyAccessMode(PropertyAccessMode.Property);
        }

        private void ConfigureCommentsTable(EntityTypeBuilder<RaidEvent> builder)
        {
            builder.OwnsMany(m => m.Comments, cb =>
            {
                cb.ToTable("Comments");

                cb.WithOwner().HasForeignKey("RaidEventId");

                cb.HasKey("Id", "RaidEventId");

                cb.Property(s => s.Id)
                .HasColumnName("CommentId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => CommentId.Create(value)
                    );

                cb.Property(s => s.Author)
                .HasConversion(
                id => id.Value,
                value => UserId.Create(value)
                );
            });
        }

        private void ConfigureAttendances(EntityTypeBuilder<RaidEvent> builder)
        {
            builder.OwnsMany(m => m.Attendances, ab =>
            {
                ab.ToTable("RaidEventAttendances");
                ab.WithOwner().HasForeignKey("RaidEventId");
                ab.HasKey("Id", "RaidEventId");

                ab.Property(s => s.Id)
                    .HasColumnName("RaidEventAttendanceId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => RaidEventAttendanceId.Create(value)
                    );

                ab.Property(s => s.CharacterId)
                    .HasConversion(
                    id => id.Value,
                    value => CharacterId.Create(value)
                    );

            });
        }
    }
}
