using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Infrastructure.Authentication.Security
{
    public class BCryptSettings
    {
        public const string SectionName = "BCrypt";

        public int WorkFactor { get; set; }
    }
}
