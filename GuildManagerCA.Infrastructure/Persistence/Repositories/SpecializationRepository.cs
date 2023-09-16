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
    public class SpecializationRepository : ISpecializationRepository
    {
        private readonly GuildManagerDbContext _dbContext;

        public SpecializationRepository(GuildManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(Specialization specialization)
        {
            await _dbContext.Specializations.AddAsync(specialization);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Specialization>> GetAllAsync()
        {
            return await _dbContext.Specializations.ToListAsync();
        }

        public async Task<List<Specialization>> GetAllActiveAsync()
        {
            return await _dbContext.Specializations
                .Where(s=>s.IsActive)
                .ToListAsync();
        }

        public async Task<Specialization?> GetById(SpecializationId id)
        {
            return await _dbContext.Specializations
                .SingleOrDefaultAsync(s => s.Id == id);
        }
    }
}
