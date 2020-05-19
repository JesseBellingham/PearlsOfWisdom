using System;
using System.Threading.Tasks;
using FluentAssertions;
using PearlsOfWisdom.Application.KeyPoints.Commands.CreateKeyPoint;
using PearlsOfWisdom.Application.PearlItems.Commands.CreatePearlItem;
using PearlsOfWisdom.Application.PearlLists.Commands.CreatePearlList;
using PearlsOfWisdom.Domain.Entities;

namespace PearlsOfWisdom.Application.IntegrationTests.KeyPoints.Commands
{
    using static Testing;
    
    public class CreateKeyPoint_TestHarness
    {
        private string _userId;
        private string _text;
        private KeyPoint _keyPoint;
        private CreateKeyPointCommand _command;
        
        public CreateKeyPoint_TestHarness WithText(string text)
        {
            _text = text;
            return this;
        }
        
        public async Task<CreateKeyPoint_TestHarness> Build()
        {
            _userId = await RunAsDefaultUserAsync();
            var pearlListId = await SendAsync(new CreatePearlListCommand { Title = "Some list title"});
            var pearlItemId = await SendAsync(new CreatePearlItemCommand { Title = "Some title", ListId = pearlListId });

            _command = new CreateKeyPointCommand { Text = _text, PearlItemId = pearlItemId };
            var keyPointId = await SendAsync(_command);
            _keyPoint = await FindAsync<KeyPoint>(keyPointId);
            
            return this;
        }

        public void Key_Point_Was_Successfully_Created_With_Correct_Title()
        {
            _keyPoint.Text.Should().Be(_text);
            _keyPoint.PearlItemId.Should().Be(_command.PearlItemId);
            _keyPoint.CreatedBy.Should().Be(_userId);
            _keyPoint.Created.Should().BeCloseTo(DateTime.Now, 10000);
            _keyPoint.LastModifiedBy.Should().BeNull();
            _keyPoint.LastModified.Should().BeNull();
        }
    }
}