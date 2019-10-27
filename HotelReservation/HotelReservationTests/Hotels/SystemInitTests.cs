using HotelReservation.Hotels;
using FluentAssertions;
using NUnit.Framework;

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
