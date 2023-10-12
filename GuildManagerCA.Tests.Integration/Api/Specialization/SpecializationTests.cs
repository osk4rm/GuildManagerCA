using AutoFixture;
using FluentAssertions;
using GuildManagerCA.Application.ClassSpecializations.Commands.Create;
using GuildManagerCA.Contracts.ClassSpecializations;
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

        [Theory]
        [MemberData(nameof(CreateSpecializationRequestTestData.GetCreateSpecializationRequestValidData), MemberType = typeof(CreateSpecializationRequestTestData))]
        public async Task Create_WithValidInput_ShouldReturn201Created(CreateSpecializationRequest request)
        {
            //act
            var response = await HttpClient.PostAsync("api/Specializations/create", request.ToJsonHttpContent());

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task GetAll_ReturnsAllSpecializations()
        {
            //arrange
            await SeedDummyData();

            //act
            var response = await HttpClient.GetAsync("api/Specializations/getall");

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await response.Content.ReadFromJsonAsync<List<SpecializationResponse>>();
            content.Count.Should().Be(4);
        }

        [Fact]
        public async Task GetById_ForValidId_ReturnsCorrectData()
        {
            //arrange
            CreateSpecializationRequest createSpecializationRequest = new CreateSpecializationRequest(
                "dummy",
                "class",
                "http://someurl.com",
                "http://anotherurl.com",
                SpecializationRole.Healer);
            var createResponse = await HttpClient.PostAsync("api/Specializations/create", createSpecializationRequest.ToJsonHttpContent());
            var createdSpecId = await createResponse.Content.ReadAsStringAsync();

            //act
            var response = await HttpClient.GetAsync($"api/Specializations/get/{createdSpecId}");

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var content = await response.Content.ReadFromJsonAsync<SpecializationResponse>();
            content.ClassName.Should().Be("class");
            content.SpecializationRole.ToLower().Should().Be("healer");
        }

        private async Task SeedDummyData()
        {
            var requests = CreateSpecializationRequestTestData.GetCreateSpecializationRequestValidData();
            foreach (var request in requests)
            {
                await HttpClient.PostAsync("api/Specializations/create", request.FirstOrDefault()?.ToJsonHttpContent());
            }
        }
    }
}
