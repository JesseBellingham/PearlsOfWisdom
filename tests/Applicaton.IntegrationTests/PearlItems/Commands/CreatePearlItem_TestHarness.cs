using System;
using System.Threading.Tasks;
using FluentAssertions;
using PearlsOfWisdom.Application.PearlItems.Commands.CreatePearlItem;
using PearlsOfWisdom.Application.PearlLists.Commands.CreatePearlList;
using PearlsOfWisdom.Domain.Entities;

namespace PearlsOfWisdom.Application.IntegrationTests.PearlItems.Commands
{
    using static Testing;
    
    public static class CreatePearlItem_TestHarness
    {
        private static string _userId;
        private static PearlItem _item;
        private static CreatePearlItemCommand _command;
        
        public static async Task Build()
        {
            _userId = await RunAsDefaultUserAsync();

            var listId = await SendAsync(new CreatePearlListCommand
            {
                Title = "New List"
            });

            _command = new CreatePearlItemCommand
            {
                ListId = listId,
                Title = "Tasks"
            };

            var itemId = await SendAsync(_command);

            _item = await FindAsync<PearlItem>(itemId);
            
        }

        public static void Pearl_Item_Was_Created_Successfully_Based_Off_Command()
        {
            _item.Should().NotBeNull();
            _item.ListId.Should().Be(_command.ListId);
            _item.Title.Should().Be(_command.Title);
            _item.CreatedBy.Should().Be(_userId);
            _item.Created.Should().BeCloseTo(DateTime.Now, 10000);
            _item.LastModifiedBy.Should().BeNull();
            _item.LastModified.Should().BeNull();
        }
    }
}