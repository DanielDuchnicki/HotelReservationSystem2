using HotelReservation.ReservationSteps.Reservation;
using HotelReservation;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using HotelReservation.ReservationSteps;
using System.Collections.Generic;
using System.Net.Mail;
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
            _name = new StepInput(typeof(string), QuestionIdentifier.Name);
            _email = new StepInput(typeof(MailAddress), QuestionIdentifier.EmailAddress);
        }

        [Test]
        public void ShouldCreateNewReservationStartProcessObject()
        {
            var reservationStartProcess = new ReservationStartProcess(_consolePrinterDouble);
            reservationStartProcess.Should().BeOfType(typeof(ReservationStartProcess));
        }

        [Test]
        public void ShouldProvideReservationStartProcessInputs()
        {
            var stepInputs = new List<StepInput> { _name, _email };

            _subject.GetStepInputs().Should().BeEquivalentTo(stepInputs);
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
            _name.SetValue("Test value");

            _subject.Execute(new List<StepInput> { _name });

            A.CallTo(() => _consolePrinterDouble.Write("Test value")).MustHaveHappened();
        }

        [Test]
        public void ShouldThrowExceptionWhenNoStepInputProvided()
        {
            var incorrectStepInput = new StepInput(typeof(string), (QuestionIdentifier)(-1));

            Action act = () => _subject.Execute(new List<StepInput> { incorrectStepInput });
            act.Should().Throw<NullReferenceException>().WithMessage("StepInput hasn't been correctly set!");
        }
    }
}
