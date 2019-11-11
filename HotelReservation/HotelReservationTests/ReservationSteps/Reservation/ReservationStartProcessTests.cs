using HotelReservation.ReservationSteps.Reservation;
using HotelReservation;
using FakeItEasy;
using NUnit.Framework;
using HotelReservation.ReservationSteps;
using System.Collections.Generic;

namespace HotelReservationTests.ReservationSteps.Reservation
{
    [TestFixture]
    class ReservationStartProcessTests
    {
        ReservationStartProcess _subject;

        [SetUp]
        public void BeforeTest()
        {
            _subject = new ReservationStartProcess();
        }

        [Test]
        public void ShouldCallConsolePrinter()
        {
            var consolePrinterDouble = A.Fake<ConsolePrinter>();
            var stepInputDouble = new StepInput(typeof(string), "name", "");
            stepInputDouble.setValue("");

            _subject.Execute(consolePrinterDouble, new List<StepInput> { stepInputDouble });

            A.CallTo(() => consolePrinterDouble.Execute("----==== RESERVATION PROCESS ====----")).MustHaveHappened();
        }

        [Test]
        public void ShouldCallConsolePrinterWithProvidedArgument()
        {
            var consolePrinterDouble = A.Fake<ConsolePrinter>();
            var stepInputDouble = new StepInput(typeof(string), "name", "");
            stepInputDouble.setValue("Test value");

            _subject.Execute(consolePrinterDouble, new List<StepInput> { stepInputDouble });

            A.CallTo(() => consolePrinterDouble.Execute("Test value")).MustHaveHappened();
        }

    }
}
