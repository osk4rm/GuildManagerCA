﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Contracts.Authentication
{
    public record ChangePasswordResponse(string Email, string PasswordHash);
}
