using HotelReservation.Hotels;
using NUnit.Framework;
using FluentAssertions;

namespace HotelReservationTests.Hotels
{
    [TestFixture]
    class SystemInitTests
    {
        [Test]
        public void ShouldAddTwoHotelsToHotelsList()
        {
            var hotelSystem = new HotelSystem();
            new SystemInit().AddHotels(hotelSystem);
            hotelSystem.GetHotels().Should().HaveCount(2);
        }
    }
}
