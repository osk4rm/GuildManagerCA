using GuildManagerCA.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Domain.SpecializationAggregate.ValueObjects
{
    public class CharacterClass : ValueObject
    {
        public string Name { get; private set; }
        public Uri ImageUrl { get; private set; }

        private CharacterClass(string name, Uri imageUrl)
        {
            Name = name;
            ImageUrl = imageUrl;
        }

        public static CharacterClass Create(string name, Uri imageUrl) => new(name, imageUrl);

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return ImageUrl;
        }
    }
}
