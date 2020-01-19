using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            var stepOutput = new StepOutput(true, new List<InputType>());
            stepOutput.IsSuccessful.Should().BeTrue();
        }

        [Test]
        public void ShouldCreateNewStepOutputWithProvidedIncorrectInputTypes()
        {
            var incorrectInputTypes = new List<InputType> {(InputType)(-1)};

            var stepOutput = new StepOutput(false, incorrectInputTypes);

            stepOutput.IncorrectInputsTypes.Should().BeEquivalentTo(incorrectInputTypes);
        }
    }
}
