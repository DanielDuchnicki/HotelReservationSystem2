using HotelReservation.ReservationSteps.Reservation;
using HotelReservation;
using FakeItEasy;
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
        private ConsolePrinter _consolePrinterDouble;
        private StepInput _name;

        [SetUp]
        public void BeforeTest()
        {
            _consolePrinterDouble = A.Fake<ConsolePrinter>();
            _subject = new ReservationStartProcess(_consolePrinterDouble);
            _name = new StepInput(InputType.Name);
        }

        [Test]
        public void ShouldProvideReservationStartProcessInputs()
        {
            var stepInputs = new List<StepInput> { _name };

            _subject.GetRequiredStepInputs().Should().BeEquivalentTo(stepInputs);
        }

        [Test]
        public void ExecuteShouldCallConsolePrinterWithStepName()
        {
            _subject.Execute(new List<StepInput> { _name });

            A.CallTo(() => _consolePrinterDouble.Write("----==== RESERVATION PROCESS ====----")).MustHaveHappened();
        }

        [Test]
        public void ShouldCallConsolePrinterWithProvidedArgument()
        {
            const string nameValue = "Test value";

            _name.Value = nameValue;

            _subject.Execute(new List<StepInput> { _name });

            A.CallTo(() => _consolePrinterDouble.Write(nameValue)).MustHaveHappened();
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
        public void ShouldReturnStepOutputWithTrueResultForCorrectStepInput()
        {
            const string nameValue = "Test Name";
            _name.Value = nameValue;

            var stepOutput = _subject.Execute(new List<StepInput> { _name });

            stepOutput.Result.Should().BeTrue();
        }

        [Test]
        public void ShouldReturnStepOutputWithCertainMessageForCorrectStepInput()
        {
            const string nameValue = "Test Name";
            _name.Value = nameValue;
            const string message = "Your name: " + nameValue + ". Step finished with success!";

            var stepOutput = _subject.Execute(new List<StepInput> { _name });

            stepOutput.Message.Should().Be(message);
        }

        [Test]
        public void ShouldReturnStepOutputWithFalseResultForIncorrectStepInput()
        {
            const string nameValue = "";
            _name.Value = nameValue;

            var stepOutput = _subject.Execute(new List<StepInput> { _name });

            stepOutput.Result.Should().BeFalse();
        }

        [Test]
        public void ShouldReturnStepOutputWithCertainMessageForIncorrectStepInput()
        {
            const string nameValue = "";
            _name.Value = nameValue;
            const string message = "Your provided incorrect name";

            var stepOutput = _subject.Execute(new List<StepInput> { _name });

            stepOutput.Message.Should().Be(message);
        }
    }
}
