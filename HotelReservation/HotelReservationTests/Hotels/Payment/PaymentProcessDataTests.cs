using HotelReservation.ReservationSteps;
using HotelReservation.ReservationSteps.Payment;
using FluentAssertions;
using NUnit.Framework;

namespace HotelReservationTests.Hotels.Payment
{
    [TestFixture]
    public class PaymentProcessDataTests
    {
        [Test]
        public void ShouldCreatePaymentProcessDataWithCorrectReservationType()
        {
            var paymentProcessData = new PaymentProcessData(0);
            paymentProcessData.ReservationStep.Should().Be(ReservationStepType.PaymentProcess);
        }

        [Test]
        public void ShouldCreatePaymentProcessDataWithProvidedPrice()
        {
            var paymentProcessData = new PaymentProcessData(11.22);
            paymentProcessData.Price.Should().Be(11.22);
        }
    }
}
