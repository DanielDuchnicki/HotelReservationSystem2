using HotelReservation.ReservationSteps;
using HotelReservation.ReservationSteps.Hotel;
using HotelReservation.ReservationSteps.Mail;
using HotelReservation.ReservationSteps.Payment;
using FluentAssertions;
using NUnit.Framework;

namespace HotelReservationTests.ReservationSteps
{
    [TestFixture]
    class StepFactoryTests
    {
        StepFactory _subject;

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
    }
}
