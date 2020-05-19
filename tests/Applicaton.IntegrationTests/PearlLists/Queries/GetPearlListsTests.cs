using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using PearlsOfWisdom.Application.PearlLists.Queries.GetPearlLists;

namespace PearlsOfWisdom.Application.IntegrationTests.PearlLists.Queries
{
    using static Testing;

    public class GetPearlListsTests : TestBase
    {
        [Test]
        public async Task Should_Get_All_Lists_And_Items()
        {
            var query = new GetPearlListsQuery();

            var result = await SendAsync(query);

            result.Lists.Should().HaveCount(0);
        }
    }
}
