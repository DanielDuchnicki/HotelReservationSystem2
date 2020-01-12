using System;
using HotelReservation.ReservationSteps;
using HotelReservation.ReservationSteps.Reservation;
using HotelReservation.ReservationSteps.Mail;
using HotelReservation.ReservationSteps.Payment;
using FluentAssertions;
using NUnit.Framework;

namespace HotelReservationTests.ReservationSteps
{
    [TestFixture]
    public class StepFactoryTests
    {
        private StepFactory _subject;

        [SetUp]
        public void BeforeTest()
        {
            _subject = new StepFactory();
        }

        [Test]
        public void ShouldCreateReservationProcessStepInstance()
        {
            _subject.CreateInstance(ReservationStepType.ReservationProcess).Should().BeOfType(typeof(ReservationStartProcess));
        }

        [Test]
        public void ShouldCreateSendingMailProcessStepInstance()
        {
            _subject.CreateInstance(ReservationStepType.SendingMailProcess).Should().BeOfType(typeof(SendingMailProcess));
        }

        [Test]
        public void ShouldCreatePaymentProcessStepInstance()
        {
            _subject.CreateInstance(ReservationStepType.PaymentProcess).Should().BeOfType(typeof(PaymentProcess));
        }

        [Test]
        public void ShouldThrowExceptionForNotValidReservationStep()
        {
            Action act = () => _subject.CreateInstance((ReservationStepType)(-1));
            act.Should().Throw<NotImplementedException>().WithMessage("There is no implementation of IReservationStep interface for given Reservation Step Type");
        }
    }
}
