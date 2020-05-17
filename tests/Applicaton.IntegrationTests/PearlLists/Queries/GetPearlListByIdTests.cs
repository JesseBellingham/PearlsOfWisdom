using System.Threading.Tasks;
using NUnit.Framework;

namespace PearlsOfWisdom.Application.IntegrationTests.PearlLists.Queries
{
    using static Testing;
    
    public class GetPearlListByIdTests : TestBase
    {
        [Test]
        public async Task Should_Get_Correct_Pearl_List_By_Id()
        {
            var sut = await new GetPearlListById_TestHarness()
                .WithUser(await RunAsDefaultUserAsync())
                .WithListTitle("Some list title")
                .Build();
            
            sut.CorrectListWasRetrieved();
        }
    }
}