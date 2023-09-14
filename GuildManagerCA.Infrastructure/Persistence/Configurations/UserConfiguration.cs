using GuildManagerCA.Domain.UserAggregate;
using GuildManagerCA.Domain.UserAggregate.ValueObjects;
using GuildManagerCA.Domain.UserRoleAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            // Primary Key
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id)
                   .HasColumnName("UserId")
                   .ValueGeneratedNever();

            builder.Property(u => u.Id)
                .HasConversion(
                id => id.Value,
                value => UserId.Create(value));

            builder.Property(u => u.UserRoleId)
                .HasConversion(
                id => id.Value,
                value => UserRoleId.Create(value));

            builder.Property(u => u.FirstName)
                   .HasMaxLength(100);

            builder.Property(u => u.LastName)
                   .HasMaxLength(100);

            builder.Property(u => u.Nickname)
                   .HasMaxLength(50);

            builder.Property(u => u.Email)
                   .HasMaxLength(150);

            builder.Property(u => u.Password)
                   .HasMaxLength(256);
        }
    }
}
