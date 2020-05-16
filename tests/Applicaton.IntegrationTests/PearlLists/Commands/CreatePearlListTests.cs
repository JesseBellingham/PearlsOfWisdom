using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using PearlsOfWisdom.Application.Common.Exceptions;
using PearlsOfWisdom.Application.PearlLists.Commands.CreatePearlList;

namespace PearlsOfWisdom.Application.IntegrationTests.PearlLists.Commands
{
    using static Testing;
    
    public class CreatePearlListTests : TestBase
    {
        [Test]
        public void Should_Require_Minimum_Fields()
        {
            var command = new CreatePearlListCommand();

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<ValidationException>();
        }
        
        [Test]
        public async Task Should_Create_Pearl_List()
        {
            await CreatePearlList_TestHarness.Build();
            CreatePearlList_TestHarness.Pearl_List_Was_Created_Successfully_Based_Off_Command();
        }
    }
}