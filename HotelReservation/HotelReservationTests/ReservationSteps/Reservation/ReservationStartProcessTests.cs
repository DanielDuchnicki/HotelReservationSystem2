using HotelReservation.ReservationSteps.Reservation;
using FluentAssertions;
using NUnit.Framework;
using HotelReservation.ReservationSteps;
using System.Collections.Generic;
using System;

namespace HotelReservationTests.ReservationSteps.Reservation
{
    [TestFixture]
    public class ReservationStartProcessTests
    {
        private ReservationStartProcess _subject;

        [SetUp]
        public void BeforeTest()
        {
            _subject = new ReservationStartProcess();
        }

        [Test]
        public void ShouldProvideReservationStartProcessInputs()
        {
            var stepInputs = new List<StepInput> { new StepInput(InputType.Name) };

            _subject.GetRequiredStepInputs().Should().BeEquivalentTo(stepInputs);
        }
        
        [Test]
        public void ShouldThrowExceptionWhenNameInputIsMissing()
        {
            const InputType unexpectedInputType = (InputType)(-1);
            var incorrectStepInput = new StepInput(unexpectedInputType);

            Action act = () => _subject.Execute(new List<StepInput> { incorrectStepInput });
            act.Should().Throw<NullReferenceException>().WithMessage("StepInput hasn't been correctly set!");
        }

        [Test]
        public void ShouldReturnStepOutputWithSuccessfulResultForCorrectStepInput()
        {
            const string nameValue = "Test Name";
            var name = new StepInput(InputType.Name) {Value = nameValue};

            var stepOutput = _subject.Execute(new List<StepInput> { name });

            stepOutput.IsSuccessful.Should().BeTrue();
        }

        [Test]
        public void ShouldReturnStepOutputWithEmptyIncorrectStepsInputsForCorrectStepInput()
        {
            const string nameValue = "Test name value";
            var name = new StepInput(InputType.Name) { Value = nameValue };

            var stepOutput = _subject.Execute(new List<StepInput> { name });

            stepOutput.IncorrectInputsTypes.Should().BeEmpty();
        }

        [Test]
        public void ShouldReturnStepOutputWithNotSuccessfulResultForEmptyStepInput()
        {
            const string nameValue = "";
            var name = new StepInput(InputType.Name) { Value = nameValue };

            var stepOutput = _subject.Execute(new List<StepInput> { name });

            stepOutput.IsSuccessful.Should().BeFalse();
        }

        [Test]
        public void ShouldReturnStepOutputWithExpectedIncorrectInputTypesForEmptyStepInput()
        {
            const string nameValue = "";
            var name = new StepInput(InputType.Name) { Value = nameValue };
            var expectedIncorrectStepInputTypes = new List<InputType> { InputType.Name };

            var stepOutput = _subject.Execute(new List<StepInput> { name });

            stepOutput.IncorrectInputsTypes.Should().BeEquivalentTo(expectedIncorrectStepInputTypes);
        }
    }
}
