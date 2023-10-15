using AutoFixture;
using FluentAssertions;
using GuildManagerCA.Application.ClassSpecializations.Commands.Create;
using GuildManagerCA.Contracts.ClassSpecializations;
using GuildManagerCA.Contracts.ClassSpecializations.Create;
using GuildManagerCA.Domain.SpecializationAggregate.Enum;
using GuildManagerCA.Tests.Integration.Api.Specialization.TestData;
using GuildManagerCA.Tests.Integration.Setup;
using GuildManagerCA.Tests.Integration.Utils;
using Microsoft.AspNetCore.Mvc;
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

        [Fact]
        public async Task GetById_ForInvalidGuid_ReturnsErrorInvalidSpecializationId()
        {
            //arrange
            string invalidGuid = "iAmNotValidGuid";

            //act
            var response = await HttpClient.GetAsync($"api/Specializations/get/{invalidGuid}");

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            var content = await response.Content.ReadFromJsonAsync<ValidationProblemDetails>();
            content.Type.Should().Be("https://tools.ietf.org/html/rfc7231#section-6.5.1");
            content.Title.Should().Be("Bad Request");
            content.Status.Should().Be(400);
            content.Errors.Count().Should().Be(1);
            content.Errors.ContainsKey("Specialization.InvalidSpecializationId").Should().BeTrue();
            
        }

        [Fact]
        public async Task GetByClassName_ForValidClassName_ReturnsCorrectResult()
        {
            //arrange
            await SeedDummyData();

            //act
            var response = await HttpClient.GetAsync($"api/Specializations/getbyclassname?className=hunter");

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var content = await response.Content.ReadFromJsonAsync<List<SpecializationResponse>>();
            content.Count.Should().Be(1);
            
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
