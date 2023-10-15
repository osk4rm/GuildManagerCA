using GuildManagerCA.Application.ClassSpecializations.Queries.GetClasses;
using GuildManagerCA.Domain.SpecializationAggregate;
using GuildManagerCA.Domain.SpecializationAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Application.Common.Persistence
{
    public interface ISpecializationRepository : IAsyncRepository<Specialization, SpecializationId>
    {
        Task CreateAsync(Specialization specialization);
        Task<List<Specialization>> GetAllActiveAsync();
        //Task<List<Specialization>> GetAllAsync();
        Task<List<Specialization>> GetByClassName(string className);
        Task<IEnumerable<ClassResult>> GetClasses();

        //Task<Specialization?> GetById(SpecializationId id);
        Task<Specialization?> SetActivity(SpecializationId id, bool isActive);

        //wondering if I want to remove it
        Task<Specialization?> UpdateSpecialization(SpecializationId id, string name, string imageUrl);
    }
}
