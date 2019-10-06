using System;
using System.Collections.Generic;
using HotelReservation.ReservationSteps;
using FluentAssertions;
using NUnit.Framework;

namespace HotelReservationTests.ReservationSteps
{
    [TestFixture]
    class StepsExecutorTests
    {
        StepsExecutor _subject;

        [SetUp]
        public void BeforeTest()
        {
            _subject = new StepsExecutor();
        }

        [Test]
        public void ShouldNotThrowExceptionForValidReservationStepsList()
        {
            var _reservationSteps = new List<ReservationStepType>()
            {
                ReservationStepType.ReservationProcess,
                ReservationStepType.PaymentProcess,
                ReservationStepType.SendingMailProcess,
            };
            Action act = () => _subject.ExecuteSteps(_reservationSteps);
            act.Should().NotThrow<Exception>();
        }

        [Test]
        public void ShouldThrowExceptionForNotValidReservationStepsList()
        {
            var _reservationSteps = new List<ReservationStepType>()
            {
                ReservationStepType.TestStep
            };
            Action act = () => _subject.ExecuteSteps(_reservationSteps);
            act.Should().Throw<Exception>().WithMessage("Something went wrong. Probably, you cannot access one of reservation steps. Please try again.");
        }
    }
}
