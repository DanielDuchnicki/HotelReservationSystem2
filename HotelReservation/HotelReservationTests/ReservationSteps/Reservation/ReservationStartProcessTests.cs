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
    class ReservationStartProcessTests
    {
        ReservationStartProcess _subject;
        ConsolePrinter _consolePrinterDouble;
        StepInput _name;
        StepInput _email;

        [SetUp]
        public void BeforeTest()
        {
            _consolePrinterDouble = A.Fake<ConsolePrinter>();
            _subject = new ReservationStartProcess(_consolePrinterDouble);
            _name = new StepInput(InputType.Name);
            _email = new StepInput(InputType.EmailAddress);
        }

        [Test]
        public void ShouldProvideReservationStartProcessInputs()
        {
            var stepInputs = new List<StepInput> { _name, _email };

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
    }
}
