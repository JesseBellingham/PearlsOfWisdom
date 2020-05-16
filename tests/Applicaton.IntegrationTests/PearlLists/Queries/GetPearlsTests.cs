using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using PearlsOfWisdom.Application.PearlLists.Queries.GetPearls;

namespace PearlsOfWisdom.Application.IntegrationTests.PearlLists.Queries
{
    using static Testing;

    public class GetPearlsTests : TestBase
    {
        [Test]
        public async Task ShouldIncludePriorityLevels()
        {
            var query = new GetPearlsQuery();

            var result = await SendAsync(query);

            result.PriorityLevels.Should().NotBeEmpty();
        }

        [Test]
        public async Task ShouldGetAllListsAndItems()
        {
            var query = new GetPearlsQuery();

            var result = await SendAsync(query);

            result.Lists.Should().HaveCount(0);
        }
    }
}
