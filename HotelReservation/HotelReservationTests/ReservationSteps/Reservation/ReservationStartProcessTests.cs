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
        private StepInput _name;

        [SetUp]
        public void BeforeTest()
        {
            _subject = new ReservationStartProcess();
            _name = new StepInput(InputType.Name);
        }

        [Test]
        public void ShouldProvideReservationStartProcessInputs()
        {
            var stepInputs = new List<StepInput> { _name };

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
            _name.Value = nameValue;

            var stepOutput = _subject.Execute(new List<StepInput> { _name });

            stepOutput.IsSuccessful.Should().BeTrue();
        }

        [Test]
        public void ShouldReturnStepOutputWithCertainMessageForCorrectStepInput()
        {
            const string nameValue = "Test Name";
            _name.Value = nameValue;
            const string message = "Your name: " + nameValue + "\nReservation start step finished with success!";

            var stepOutput = _subject.Execute(new List<StepInput> { _name });

            stepOutput.Message.Should().Be(message);
        }

        [Test]
        public void ShouldReturnStepOutputWithNotSuccessfulResultForEmptyStepInput()
        {
            const string nameValue = "";
            _name.Value = nameValue;

            var stepOutput = _subject.Execute(new List<StepInput> { _name });

            stepOutput.IsSuccessful.Should().BeFalse();
        }

        [Test]
        public void ShouldReturnStepOutputWithCertainMessageForEmptyStepInput()
        {
            const string nameValue = "";
            _name.Value = nameValue;
            const string message = "Your provided incorrect name";

            var stepOutput = _subject.Execute(new List<StepInput> { _name });

            stepOutput.Message.Should().Be(message);
        }
    }
}
