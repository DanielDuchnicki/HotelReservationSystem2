using HotelReservation.ReservationSteps;
using HotelReservation.ReservationSteps.Reservation;
using FluentAssertions;
using NUnit.Framework;

namespace HotelReservationTests.Hotels.Reservation
{
    [TestFixture]
    public class ReservationStartProcessDataTests
    {
        [Test]
        public void ShouldCreateReservationStartProcessDataWithCorrectReservationType()
        {
            var reservationStartProcessData = new ReservationStartProcessData(0);
            reservationStartProcessData.ReservationStep.Should().Be(ReservationStepType.ReservationProcess);
        }

        [Test]
        public void ShouldCreateReservationStartProcessDataWithProvidedHotelId()
        {
            var reservationStartProcessData = new ReservationStartProcessData(1);
            reservationStartProcessData.HotelId.Should().Be(1);
        }
    }
}
