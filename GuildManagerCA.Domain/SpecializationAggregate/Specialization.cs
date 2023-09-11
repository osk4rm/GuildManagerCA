using GuildManagerCA.Domain.Common.Models;
using GuildManagerCA.Domain.SpecializationAggregate.Enum;
using GuildManagerCA.Domain.SpecializationAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Domain.SpecializationAggregate
{
    public class Specialization : AggregateRoot<SpecializationId>
    {
        public string Name { get; private set; }
        public Uri ImageUrl { get; private set; }
        public SpecializationRole SpecializationRole { get; private set; }
        public CharacterClass CharacterClass { get; private set; }
        public bool IsActive { get; private set; }  

        private Specialization(
            string name,
            Uri imageUrl,
            SpecializationRole specializationRole,
            CharacterClass characterClass,
            bool isActive,
            SpecializationId? id = null) : base(id ?? SpecializationId.CreateUnique())
        {
            Name = name;
            ImageUrl = imageUrl;
            SpecializationRole = specializationRole;
            CharacterClass = characterClass;
            IsActive = isActive;
        }

        public static Specialization Create(
            string name,
            Uri imageUrl,
            SpecializationRole specializationRole,
            CharacterClass characterClass,
            bool isActive
            )
        {
            return new Specialization(name, imageUrl, specializationRole, characterClass, isActive);
        }
    }
}
