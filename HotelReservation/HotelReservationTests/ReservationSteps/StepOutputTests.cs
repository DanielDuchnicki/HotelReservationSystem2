using FluentAssertions;
using HotelReservation.ReservationSteps;
using NUnit.Framework;


namespace HotelReservationTests.ReservationSteps
{
    [TestFixture]
    public class StepOutputTests
    {
        [Test]
        public void ShouldCreateNewStepOutputWithProvidedResult()
        {
            var stepOutput = new StepOutput(true, "");
            stepOutput.IsSuccessful.Should().BeTrue();
        }

        [Test]
        public void ShouldCreateNewStepOutputWithProvidedMessage()
        {
            const string message = "Test message";

            var stepOutput = new StepOutput(false, message);

            stepOutput.Message.Should().BeEquivalentTo(message);
        }
    }
}
