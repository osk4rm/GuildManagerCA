using GuildManagerCA.Application.ClassSpecializations.Commands.Create;
using GuildManagerCA.Application.ClassSpecializations.Queries.GetAll;
using GuildManagerCA.Application.ClassSpecializations.Queries.GetById;
using GuildManagerCA.Contracts.ClassSpecializations.Create;
using GuildManagerCA.Contracts.ClassSpecializations.GetAll;
using GuildManagerCA.Domain.SpecializationAggregate;
using GuildManagerCA.Domain.SpecializationAggregate.Enum;
using Mapster;

namespace GuildManagerCA.Api.Common.Mapping
{
    public class SpecializationsMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            //create
            config.NewConfig<CreateSpecializationRequest, CreateSpecializationCommand>();
            config.NewConfig<CreateSpecializationResult, CreateSpecializationResponse>();

            //get
            config.NewConfig<Specialization, SpecializationResponse>()
                .Map(dest => dest.ClassImageUrl, src => src.CharacterClass.ImageUrl)
                .Map(dest => dest.ClassName, src => src.CharacterClass.Name)
                .Map(dest => dest.SpecializationRole, src => Enum.GetName(typeof(SpecializationRole) ,src.SpecializationRole));
            config.NewConfig<bool, GetAllSpecializationsQuery>()
                .Map(dest => dest.OnlyActive, src => src);

            //getbyid
            config.NewConfig<string, GetSpecializationByIdQuery>()
                .Map(dest => dest.Id, src => src);
        }
    }
}
