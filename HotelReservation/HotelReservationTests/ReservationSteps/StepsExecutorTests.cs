using System;
using System.Collections.Generic;
using HotelReservation.ReservationSteps;
using FluentAssertions;
using NUnit.Framework;
using Moq;

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
            Action act = () => _subject.ExecuteSteps(_reservationSteps, new StepFactory());
            act.Should().NotThrow<Exception>();
        }

        [Test]
        public void ShouldThrowExceptionForNotValidReservationStepsList()
        {
            var _reservationSteps = new List<ReservationStepType>()
            {
                (ReservationStepType)(-1)
            };
            Action act = () => _subject.ExecuteSteps(_reservationSteps, new StepFactory());
            act.Should().Throw<Exception>();
        }
    }
}
