using FluentValidation;
using GuildManagerCA.Application.Common.Persistence;
using GuildManagerCA.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManagerCA.Application.Common.Validation
{
    public static class ValidationExtensions
    {
        public static IRuleBuilderInitial<T, string> IdMustExistInDatabase<T, TEntity, TId>(
            this IRuleBuilder<T, string> ruleBuilder,
            IAsyncRepository<TEntity, TId> repository,
            Func<string, TId> idConverter,
            string entityName = null)
            where TEntity : Entity<TId>
            where TId : ValueObject
        {
            return (IRuleBuilderInitial<T, string>)ruleBuilder.CustomAsync(async (value, context, cancellationToken) =>
            {
                var id = idConverter(value);
                var entity = await repository.GetByIdAsync(id);
                if (entity is null)
                {
                    context.AddFailure($"{entityName ?? typeof(TEntity).Name} with id {value} does not exist in the database.");
                }
            });
        }
    }
}
