using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using PearlsOfWisdom.Application.Common.Exceptions;
using PearlsOfWisdom.Application.KeyPoints.Commands.CreateKeyPoint;

namespace PearlsOfWisdom.Application.IntegrationTests.KeyPoints.Commands
{
    using static Testing;
    
    public class CreateKeyPointTests : TestBase
    {
        [Test]
        public void Should_Require_Minimum_Fields()
        {
            var command = new CreateKeyPointCommand();

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<ValidationException>();
        }

        [Test]
        public async Task Should_Create_Key_Point()
        {
            var sut =
                await new CreateKeyPoint_TestHarness()
                    .WithText("Some key point")
                    .Build();
            
            sut.Key_Point_Was_Successfully_Created_With_Correct_Title();
        }
    }
}