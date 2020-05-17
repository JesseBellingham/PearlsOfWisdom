using System;
using System.Threading.Tasks;
using FluentAssertions;
using PearlsOfWisdom.Application.PearlLists.Commands.CreatePearlList;
using PearlsOfWisdom.Domain.Entities;

namespace PearlsOfWisdom.Application.IntegrationTests.PearlLists.Commands
{
    using static Testing;
    
    public class CreatePearlList_TestHarness
    {
        private static string _userId;
        private static PearlList _list;
        private static CreatePearlListCommand _command;
        private static string _title;

        public CreatePearlList_TestHarness WithUser(string userId)
        {
            _userId = userId;
            return this;
        }

        public CreatePearlList_TestHarness WithTitle(string title)
        {
            _title = title;
            return this;
        }

        public async Task<CreatePearlList_TestHarness> Build()
        {
            _command = new CreatePearlListCommand
            {
                Title = _title
            };

            var listId = await SendAsync(_command);
            _list = await FindAsync<PearlList>(listId);
            return this;
        }

        public void Pearl_List_Was_Created_Successfully_Based_Off_Command()
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