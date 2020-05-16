using System;
using System.Threading.Tasks;
using FluentAssertions;
using PearlsOfWisdom.Application.PearlLists.Commands.CreatePearlList;
using PearlsOfWisdom.Domain.Entities;

namespace PearlsOfWisdom.Application.IntegrationTests.PearlLists.Commands
{
    using static Testing;
    
    public static class CreatePearlListCommand_TestHarness
    {
        private static string _userId;
        private static PearlList _list;
        private static CreatePearlListCommand _command;

        public static async Task Build()
        {
            _userId = await RunAsDefaultUserAsync();
            _command = new CreatePearlListCommand
            {
                Title = "New List"
            };

            var listId = await SendAsync(_command);
            _list = await FindAsync<PearlList>(listId);
        }

        public static void PearlListWasCreatedSuccessfullyBasedOffCommand()
        {
            _list.Should().NotBeNull();
            _list.Title.Should().Be(_command.Title);
            _list.CreatedBy.Should().Be(_userId);
            _list.Created.Should().BeCloseTo(DateTime.Now, 10000);
            _list.LastModifiedBy.Should().BeNull();
            _list.LastModified.Should().BeNull();
        }
    }
}