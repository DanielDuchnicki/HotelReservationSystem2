using HotelReservation.Hotels;
using FluentAssertions;
using NUnit.Framework;

namespace HotelReservationTests.Hotels
{
    [TestFixture]
    public class SystemInitTests
    {
        [Test]
        public void ShouldAddThreeHotelsToHotelsList()
        {
            var hotelSystem = new HotelSystem();
            new SystemInit().AddHotels(hotelSystem);
            hotelSystem.GetHotels().Should().HaveCount(3);
        }
    }
}
