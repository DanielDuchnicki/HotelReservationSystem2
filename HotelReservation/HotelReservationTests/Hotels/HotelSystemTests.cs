using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using HotelReservation.Hotels;
using HotelReservation.ReservationSteps;
using NUnit.Framework;

namespace HotelReservationTests.Hotels
{
    [TestFixture]
    public class HotelSystemTests
    {
        [Test]
        public void ShouldAddNewHotelToTheHotelsList()
        {
            var hotelSystem = new HotelSystem();
            hotelSystem.AddNewHotel(new List<ReservationStepType>());
            hotelSystem.GetHotels().Should().HaveCount(1);
        }

        [Test]
        public void ShouldFirstAddedHotelHasIdEqual1000()
        {
            var hotelSystem = new HotelSystem();
            hotelSystem.AddNewHotel(new List<ReservationStepType>());
            hotelSystem.GetHotels().First().HotelId.Should().Be(1000);
        }

        [Test]
        public void ShouldIdsBeIncrementedForEachAddedHotel()
        {
            var hotelSystem = new HotelSystem();
            for (var counter = 0; counter < 5; counter++)
            {
                hotelSystem.AddNewHotel(new List<ReservationStepType>());
            }
            hotelSystem.GetHotels().Last().HotelId.Should().Be(1004);
        }

        [Test]
        public void ShouldProvideHotelReservationStepsList()
        {
            var reservationSteps = new List<ReservationStepType>()
            {
                ReservationStepType.ReservationProcess,
                ReservationStepType.PaymentProcess
            };
            var hotelSystem = new HotelSystem();
            hotelSystem.AddNewHotel(reservationSteps);
            hotelSystem.GetHotelReservationSteps(1000).Should().BeEquivalentTo(reservationSteps);
        }
    }
}