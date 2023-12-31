﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Contracts.Authentication
{
    public record RegisterRequest(
        string FirstName,
        string LastName,
        string NickName,
        string Email,
        string Password,
        string ConfirmPassword);
}
