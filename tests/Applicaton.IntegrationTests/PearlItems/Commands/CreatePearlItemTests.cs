using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using PearlsOfWisdom.Application.Common.Exceptions;
using PearlsOfWisdom.Application.PearlItems.Commands.CreatePearlItem;

namespace PearlsOfWisdom.Application.IntegrationTests.PearlItems.Commands
{
    using static Testing;

    public class CreatePearlItemTests : TestBase
    {
        [Test]
        public void Should_Require_Minimum_Fields()
        {
            var command = new CreatePearlItemCommand();

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<ValidationException>();
        }

        [Test]
        public async Task Should_Create_Pearl_Item()
        {
            await CreatePearlItem_TestHarness.Build();
            CreatePearlItem_TestHarness.Pearl_Item_Was_Created_Successfully_Based_Off_Command();
        }
    }
}
