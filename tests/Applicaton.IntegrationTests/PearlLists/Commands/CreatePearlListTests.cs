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
            var sut = await new CreatePearlList_TestHarness()
                .WithUser(await RunAsDefaultUserAsync())
                .WithTitle("Some list title")
                .Build();
            
            sut.Pearl_List_Was_Created_Successfully_Based_Off_Command();
        }
    }
}