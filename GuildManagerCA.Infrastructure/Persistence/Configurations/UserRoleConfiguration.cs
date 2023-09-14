using GuildManagerCA.Domain.UserRoleAggregate;
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
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRoles");

            builder.HasKey(ur => ur.Id);
            builder.Property(ur => ur.Id)
                   .HasColumnName("UserRoleId")
                   .ValueGeneratedNever();


            builder.Property(ur => ur.Id)
                   .HasConversion(
                        id => id.Value,
                        value => UserRoleId.Create(value));

            builder.Property(ur => ur.Name)
                   .IsRequired()
                   .HasMaxLength(100);

        }
    }
}
