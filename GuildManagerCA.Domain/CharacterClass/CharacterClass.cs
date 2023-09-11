using GuildManagerCA.Domain.CharacterClass.Entities;
using GuildManagerCA.Domain.CharacterClass.ValueObjects;
using GuildManagerCA.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Domain.CharacterClass
{
    public class CharacterClass : AggregateRoot<CharacterClassId>
    {
        private readonly List<ClassSpecialization> _characterSpecializations = new();
        public string Name { get; private set; }
        public Uri ImageUrl { get; private set; }
        public IReadOnlyList<ClassSpecialization> Specializations => _characterSpecializations.AsReadOnly();

        private CharacterClass(
            string name,
            Uri imageUrl) : base(CharacterClassId.CreateUnique())
        {
            Name = name;
            ImageUrl = imageUrl;
        }

        public static CharacterClass Create(
            string name,
            Uri imageUrl) => new(name, imageUrl);
    }
}
