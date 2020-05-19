using System;
using System.Threading.Tasks;
using FluentAssertions;
using PearlsOfWisdom.Application.PearlItems.Commands.CreatePearlItem;
using PearlsOfWisdom.Application.PearlLists.Commands.CreatePearlList;
using PearlsOfWisdom.Domain.Entities;

namespace PearlsOfWisdom.Application.IntegrationTests.PearlItems.Commands
{
    using static Testing;
    
    public class CreatePearlItem_TestHarness
    {
        private string _userId;
        private string _title;
        private string _author;
        private PearlItem _item;
        private CreatePearlItemCommand _command;

        public CreatePearlItem_TestHarness WithTitle(string title)
        {
            _title = title;
            return this;
        }
        
        public async Task<CreatePearlItem_TestHarness> Build()
        {
            _userId = await RunAsDefaultUserAsync();

            var listId = await SendAsync(new CreatePearlListCommand
            {
                Title = "New List"
            });

            _command = new CreatePearlItemCommand
            {
                ListId = listId,
                Title = _title,
                Author = _author
            };

            var itemId = await SendAsync(_command);

            _item = await FindAsync<PearlItem>(itemId);
            return this;
        }

        public void Pearl_Item_Was_Created_Successfully_Based_Off_Command()
        {
            _item.ListId.Should().Be(_command.ListId);
            _item.Title.Should().Be(_command.Title);
            _item.Author.Should().Be(_command.Author);
            _item.CreatedBy.Should().Be(_userId);
            _item.Created.Should().BeCloseTo(DateTime.Now, 10000);
            _item.LastModifiedBy.Should().BeNull();
            _item.LastModified.Should().BeNull();
        }
    }
}