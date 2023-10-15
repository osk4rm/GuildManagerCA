﻿using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Application.ClassSpecializations.Queries.GetClasses
{
    public record GetClassesQuery : IRequest<ErrorOr<List<ClassResult>>>;
    
    
}
