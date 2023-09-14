using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Infrastructure.Persistence.EFUtils
{
    public static class PropertyBuilderExtensions
    {
        public static PropertyBuilder<Uri> HasUriConversion(this PropertyBuilder<Uri> builder)
        {
            return builder.HasConversion(
                uri => uri.ToString(),
                str => new Uri(str));
        }
    }
}
