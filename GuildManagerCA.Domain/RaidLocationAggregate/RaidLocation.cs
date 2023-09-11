using GuildManagerCA.Domain.Common.Models;
using GuildManagerCA.Domain.RaidLocationAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Domain.RaidLocationAggregate
{
    public class RaidLocation : AggregateRoot<RaidLocationId>
    {
        public string Name { get; private set; }
        public RaidExpansion Expansion { get; private set; }
        public Uri ImageUrl { get; private set; }

        public RaidLocation(
            string name,
            RaidExpansion expansion,
            Uri imageUrl,
            RaidLocationId? id = null) : base(id ?? RaidLocationId.CreateUnique())
        {
            Name = name;
            Expansion = expansion;
            ImageUrl = imageUrl;
        }

        public static RaidLocation Create(
            string name,
            RaidExpansion expansion,
            Uri imageUrl
            )
        {
            return new RaidLocation(name, expansion, imageUrl);
        }
    }
}
