using AutoFixture;
using FluentAssertions;
using GuildManagerCA.Application.ClassSpecializations.Commands.Create;
using GuildManagerCA.Contracts.ClassSpecializations.Create;
using GuildManagerCA.Domain.SpecializationAggregate.Enum;
using GuildManagerCA.Tests.Integration.Api.Specialization.TestData;
using GuildManagerCA.Tests.Integration.Setup;
using GuildManagerCA.Tests.Integration.Utils;
using System.Net;

namespace GuildManagerCA.Tests.Integration.Api.Specialization
{
    public class SpecializationsControllerTests : BaseIntegrationTest
    {
        public SpecializationsControllerTests(IntegrationTestWebAppFactory factory) : base(factory)
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

        [Theory]
        [MemberData(nameof(CreateSpecializationRequestTestData.GetCreateSpecializationRequestValidData), MemberType = typeof(CreateSpecializationRequestTestData))]
        public async Task Create_WithValidInputAndNoAuthorization_ShouldReturn201Created(CreateSpecializationRequest request)
        {
            
            var response = await HttpClient.PostAsync("api/Specializations/create", request.ToJsonHttpContent());

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }
    }
}
