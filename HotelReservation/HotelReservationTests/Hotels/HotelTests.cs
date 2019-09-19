using System.Collections.Generic;
using HotelReservation.ReservationSteps;
using HotelReservation.Hotels;
using NUnit.Framework;
using FluentAssertions;

namespace HotelReservationTests.Hotels
{
    [TestFixture]
    public class HotelTests
    {
        [Test]
        public void ShouldCreateNewHotelWithProvidedId()
        {
            var hotel = new Hotel(1, new List<ReservationStepType>());
            hotel.HotelId.Should().Be(1);
        }

        [Test]
        public void ShouldCreateNewHotelWithProvidedListOfReservationSteps()
        {
            var reservationSteps = new List<ReservationStepType>()
            {
                ReservationStepType.ReservationProcess,
                ReservationStepType.PaymentProcess
            };
            var hotel = new Hotel(1, reservationSteps);
            hotel.ReservationSteps.Should().BeEquivalentTo(reservationSteps);
        }
    }
}
