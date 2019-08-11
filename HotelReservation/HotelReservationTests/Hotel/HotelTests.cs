using System.Collections.Generic;
using System.Linq;
using HotelReservation.ReservationSteps;
using NUnit.Framework;
using FluentAssertions;

namespace HotelReservationTests.Hotel
{
    [TestFixture]
    public class HotelTests
    {
        [Test]
        public void ShouldCreateNewHotelWithProvidedId()
        {
            var hotel = new HotelReservation.Hotel.Hotel(1, new List<ReservationSteps>());
            hotel.HotelId.Should().Be(1);
        }

        [Test]
        public void ShouldCreateNewHotelWithProvidedListOfReservationSteps()
        {
            var reservationSteps = new List<ReservationSteps>()
            {
                ReservationSteps.ReservationProcess,
                ReservationSteps.PaymentProcess
            };
            var hotel = new HotelReservation.Hotel.Hotel(1, reservationSteps);
            hotel.ReservationSteps.First().Should().Be(ReservationSteps.ReservationProcess);
            hotel.ReservationSteps.Last().Should().Be(ReservationSteps.PaymentProcess);
        }
    }
}
