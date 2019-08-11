using System.Collections.Generic;
using System.Linq;
using HotelReservation.ReservationSteps;
using NUnit.Framework;
using FluentAssertions;

namespace HotelReservationTests.Hotel.HotelSystem
{
    [TestFixture]
    public class HotelSystemTests
    {
        [Test]
        public void ShouldAddNewHotelToTheHotelsList()
        {
            var hotelSystem = new HotelReservation.Hotel.HotelSystem.HotelSystem();
            hotelSystem.AddNewHotel(new List<ReservationSteps>());
            hotelSystem.Hotels.Should().HaveCount(1);
        }

        [Test]
        public void ShouldFirstAddedHotelHasIdEqual1000()
        {
            var hotelSystem = new HotelReservation.Hotel.HotelSystem.HotelSystem();
            hotelSystem.AddNewHotel(new List<ReservationSteps>());
            hotelSystem.Hotels.First().HotelId.Should().Be(1000);
        }

        [Test]
        public void ShouldIdsBeIncrementedForEachAddedHotel()
        {
            var hotelSystem = new HotelReservation.Hotel.HotelSystem.HotelSystem();
            for (var counter = 0; counter < 5; counter++)
            {
                hotelSystem.AddNewHotel(new List<ReservationSteps>());
            }
            hotelSystem.Hotels.Last().HotelId.Should().Be(1004);
        }

        [Test]
        public void ShouldProvideHotelReservationStepsList()
        {
            var reservationSteps = new List<ReservationSteps>()
            {
                ReservationSteps.ReservationProcess,
                ReservationSteps.PaymentProcess
            };
            var hotelSystem = new HotelReservation.Hotel.HotelSystem.HotelSystem();
            hotelSystem.AddNewHotel(reservationSteps);
            hotelSystem.GetHotelReservationSteps(1000)[0].Should().Be(reservationSteps[0]);
            hotelSystem.GetHotelReservationSteps(1000)[1].Should().Be(reservationSteps[1]);
        }

        [Test]
        public void ShouldAddTwoHotelsToHotelsList()
        {
            var hotelSystem = new HotelReservation.Hotel.HotelSystem.HotelSystem();
            hotelSystem.Init();
            hotelSystem.Hotels.Should().HaveCount(2);
        }
    }
}