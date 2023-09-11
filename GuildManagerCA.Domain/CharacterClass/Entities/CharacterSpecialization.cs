using GuildManagerCA.Domain.CharacterClass.Enums;
using GuildManagerCA.Domain.CharacterClass.ValueObjects;
using GuildManagerCA.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Domain.CharacterClass.Entities
{
    public class ClassSpecialization : Entity<ClassSpecializationId>
    {
        public string Name { get; private set; }
        public SpecializationRole Role { get; private set; }
        public Uri ImageUrl { get; private set; }
        private ClassSpecialization(
            string name,
            SpecializationRole role,
            Uri imageUrl) : base(ClassSpecializationId.CreateUnique())
        {
            Name = name;
            Role = role;
            ImageUrl = imageUrl;
        }

        public static ClassSpecialization Create(string name, SpecializationRole role, Uri imageUrl)
        {
            return new ClassSpecialization(name, role, imageUrl);
        }
    }
}
