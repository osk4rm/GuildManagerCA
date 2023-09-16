using GuildManagerCA.Application.ClassSpecializations.Commands.Create;
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
        }
    }
}
