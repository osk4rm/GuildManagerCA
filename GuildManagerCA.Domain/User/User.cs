using GuildManagerCA.Domain.Common.Models;
using GuildManagerCA.Domain.User.Entities;
using GuildManagerCA.Domain.User.ValueObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Domain.User
{
    public sealed class User : AggregateRoot<UserId>
    {
        private readonly List<Role> _roles = new();

        public string FirstName { get; }
        public string LastName { get; }
        public string Nickname { get; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }

        public IReadOnlyList<Role> Roles => _roles.AsReadOnly();

        private User(
            string firstName,
            string lastName,
            string nickName,
            string email,
            string password,
            DateTime createdDateTime,
            DateTime updatedDateTime,
            UserId? id = null
            ) : base(id ?? UserId.CreateUnique())
        {
            FirstName = firstName;
            LastName = lastName;
            Nickname = nickName;
            Email = email;
            Password = password;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static User Create(
            string firstName,
            string lastName,
            string nickName,
            string email,
            string password,
            DateTime createdDateTime,
            DateTime updatedDateTime)
        {
            return new(
                firstName,
                lastName,
                nickName,
                email,
                password,
                createdDateTime,
                updatedDateTime);
        }


    }
}
