using GuildManagerCA.Domain.Common.Models;
using GuildManagerCA.Domain.UserAggregate.ValueObjects;
using GuildManagerCA.Domain.UserRoleAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Domain.UserAggregate
{
    public sealed class User : AggregateRoot<UserId>
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Nickname { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }
        public UserRoleId UserRoleId { get; private set; }


        private User(
            string firstName,
            string lastName,
            string nickName,
            string email,
            string password,
            DateTime createdDateTime,
            DateTime updatedDateTime,
            UserRoleId userRoleId,
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
            UserRoleId = userRoleId;
        }

        public static User Create(
            string firstName,
            string lastName,
            string nickName,
            string email,
            string password,
            DateTime createdDateTime,
            DateTime updatedDateTime,
            UserRoleId userRoleId)
        {
            return new(
                firstName,
                lastName,
                nickName,
                email,
                password,
                createdDateTime,
                updatedDateTime,
                userRoleId);
        }


    }
}
