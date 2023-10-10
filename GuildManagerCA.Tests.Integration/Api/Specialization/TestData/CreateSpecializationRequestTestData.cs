using GuildManagerCA.Contracts.ClassSpecializations.Create;
using GuildManagerCA.Domain.SpecializationAggregate.Enum;

namespace GuildManagerCA.Tests.Integration.Api.Specialization.TestData
{
    public class CreateSpecializationRequestTestData
    {
        public static IEnumerable<object[]> GetCreateSpecializationRequestValidData()
        {
            var list = new List<CreateSpecializationRequest>
            {
                new CreateSpecializationRequest("Marksman", "Hunter", "http://www.hunter.com/hunter.jpg", "http://test.com/marksman.jpg" , SpecializationRole.RangedDPS),
                new CreateSpecializationRequest("Frost", "Death knight", "http://www.hunter.com/hunter.jpg", "http://test.com/marksman.jpg" , SpecializationRole.MeleeDPS),
                new CreateSpecializationRequest("Protection", "Warrior", "http://www.hunter.com/hunter.jpg", "http://test.com/marksman.jpg" , SpecializationRole.Tank),
                new CreateSpecializationRequest("Restoration", "Druid", "http://www.hunter.com/hunter.jpg", "http://test.com/marksman.jpg" , SpecializationRole.Healer)
            };

            return list.Select(l => new object[] { l });
        }
    }
}
