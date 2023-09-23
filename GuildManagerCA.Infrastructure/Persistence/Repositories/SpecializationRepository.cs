using ErrorOr;
using GuildManagerCA.Application.Common.Persistence;
using GuildManagerCA.Domain.SpecializationAggregate;
using GuildManagerCA.Domain.SpecializationAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Infrastructure.Persistence.Repositories
{
    public class SpecializationRepository : RepositoryBase<Specialization, SpecializationId>, ISpecializationRepository
    {
        public SpecializationRepository(GuildManagerDbContext dbContext) : base(dbContext)
        {
        }

        public async Task CreateAsync(Specialization specialization)
        {
            await _dbContext.Specializations.AddAsync(specialization);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Specialization>> GetAllActiveAsync()
        {
            return await _dbContext.Specializations
                .Where(s=>s.IsActive)
                .ToListAsync();
        }

        public async Task<List<Specialization>> GetByClassName(string className)
        {
            return await _dbContext.Specializations
                .Where(s => s.CharacterClass.Name == className)
                .ToListAsync();
        }

        public async Task<Specialization?> UpdateSpecialization(SpecializationId id, string name, string imageUrl)
        {
            if(await _dbContext.Specializations
                .Where(s => s.Id == id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(sp => sp.Name, name)
                .SetProperty(sp => sp.ImageUrl, new Uri(imageUrl))) < 1)
            {
                return null;
            }

            return _dbContext.Specializations.SingleOrDefault(s => s.Id == id);
            
        }

        public async Task<Specialization?> SetActivity(SpecializationId id, bool isActive)
        {
            if (await _dbContext.Specializations
                .Where(s => s.Id == id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(sp => sp.IsActive, isActive)) < 1)
            {
                return null;
            }

            return _dbContext.Specializations.SingleOrDefault(s => s.Id == id);
        }
    }
}
