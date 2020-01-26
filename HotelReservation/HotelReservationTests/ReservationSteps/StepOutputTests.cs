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
        public void ShouldCreateNewStepOutputWithProvidedIncorrectInputTypes()
        {
            var incorrectInputTypes = new List<InputType> {(InputType)(-1)};

            var stepOutput = new StepOutput(incorrectInputTypes);

            stepOutput.IncorrectInputsTypes.Should().BeEquivalentTo(incorrectInputTypes);
        }
    }
}
