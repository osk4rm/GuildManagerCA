using FluentAssertions;
using GuildManagerCA.Application.ClassSpecializations.Commands.Create;
using GuildManagerCA.Domain.SpecializationAggregate.Enum;
using GuildManagerCA.Tests.Integration.Setup;

namespace GuildManagerCA.Tests.Integration.Specialization
{
    public class SpecializationTests : BaseIntegrationTest
    {
        public SpecializationTests(IntegrationTestWebAppFactory factory) : base(factory)
        {

        }

        [Fact]
        public async Task Create_ShouldAdd_NewSpecialization()
        {
            //arrange
            var command = new CreateSpecializationCommand("Marksman", "Hunter", "http://hunter.com/hunter.jpg", "http://marksman.com", SpecializationRole.RangedDPS);

            //act
            var result = await _sender.Send(command);

            //assert
            result.Value.Should().BeAssignableTo<CreateSpecializationResult>();
        }
    }
}
