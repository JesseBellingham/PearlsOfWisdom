using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using PearlsOfWisdom.Application.Common.Exceptions;
using PearlsOfWisdom.Application.PearlLists.Commands.CreatePearlList;
using PearlsOfWisdom.Domain.Entities;

namespace PearlsOfWisdom.Application.IntegrationTests.PearlLists.Commands
{
    using static Testing;
    
    public class CreatePearlListTests : TestBase
    {
        [Test]
        public void ShouldRequireMinimumFields()
        {
            var command = new CreatePearlListCommand();

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<ValidationException>();
        }
        
        [Test]
        public async Task ShouldCreatePearlList()
        {
            await CreatePearlListCommand_TestHarness.Build();
            CreatePearlListCommand_TestHarness.PearlListWasCreatedSuccessfullyBasedOffCommand();
        }
    }
}