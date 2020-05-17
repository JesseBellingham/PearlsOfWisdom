using System;
using System.Threading.Tasks;
using FluentAssertions;
using PearlsOfWisdom.Application.PearlLists.Commands.CreatePearlList;
using PearlsOfWisdom.Application.PearlLists.Queries.GetPearlListById;
using PearlsOfWisdom.Domain.Entities;

namespace PearlsOfWisdom.Application.IntegrationTests.PearlLists.Queries
{
    using static Testing;
    
    public class GetPearlListById_TestHarness
    {
        private string _userId;
        private string _listTitle;
        private Guid _listId;
        private PearlListVm _list;

        public GetPearlListById_TestHarness WithUser(string userId)
        {
            _userId = userId;
            return this;
        }

        public GetPearlListById_TestHarness WithListTitle(string title)
        {
            _listTitle = title;
            return this;
        }
        public async Task<GetPearlListById_TestHarness> Build()
        {
            _listId = await SendAsync(new CreatePearlListCommand
            {
                Title = _listTitle
            });
            _list = await SendAsync(new GetPearlListByIdQuery { ListId = _listId });
            return this;
        }

        public void CorrectListWasRetrieved()
        {
            _list.Should().NotBeNull();
            _list.List.Id.Should().Be(_listId);
            _list.List.Title.Should().Be(_listTitle);
        }
    }
}