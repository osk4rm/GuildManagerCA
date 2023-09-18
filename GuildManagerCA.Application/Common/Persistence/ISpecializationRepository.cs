using GuildManagerCA.Domain.SpecializationAggregate;
using GuildManagerCA.Domain.SpecializationAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Application.Common.Persistence
{
    public interface ISpecializationRepository
    {
        Task CreateAsync(Specialization specialization);
        Task<List<Specialization>> GetAllActiveAsync();
        Task<List<Specialization>> GetAllAsync();
        Task<List<Specialization>> GetByClassName(string className);
        Task<Specialization?> GetById(SpecializationId id);
    }
}
