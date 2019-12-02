using HotelReservation.ReservationSteps.Reservation;
using HotelReservation;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using HotelReservation.ReservationSteps;
using System.Collections.Generic;

namespace HotelReservationTests.ReservationSteps.Reservation
{
    [TestFixture]
    class ReservationStartProcessTests
    {
        ReservationStartProcess _subject;
        ConsolePrinter _consolePrinterDouble;

        [SetUp]
        public void BeforeTest()
        {
            _consolePrinterDouble = A.Fake<ConsolePrinter>();
            _subject = new ReservationStartProcess(_consolePrinterDouble);
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
            var name = new StepInput(typeof(string), QuestionIdentifier.Name);
            var stepInputs = new List<StepInput> { name };

            _subject.GetStepInputs().Should().BeEquivalentTo(stepInputs);
        }

        [Test]
        public void ExecuteShouldCallConsolePrinterWithStepName()
        {
            var stepInputDouble = new StepInput(typeof(string), QuestionIdentifier.Name);
            stepInputDouble.SetValue("");

            _subject.Execute();

            A.CallTo(() => _consolePrinterDouble.Write("----==== RESERVATION PROCESS ====----")).MustHaveHappened();
        }
    }
}
