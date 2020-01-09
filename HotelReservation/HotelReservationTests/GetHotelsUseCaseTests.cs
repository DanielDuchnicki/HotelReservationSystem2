using HotelReservation.Hotels;
using NUnit.Framework;
using FakeItEasy;
using System.Collections.Generic;
using HotelReservation;
using System.Collections.ObjectModel;
using FluentAssertions;

namespace HotelReservationTests
{
    [TestFixture]
    public class GetHotelsUseCaseTests
    {
        private GetHotelsUseCase _subject;
        private HotelSystem _hotelSystemDouble;

        [SetUp]
        public void BeforeTest()
        {
            _hotelSystemDouble = A.Fake<HotelSystem>();
            _subject = new GetHotelsUseCase(_hotelSystemDouble);
        }

        [Test]
        public void ShouldRetrieveAvailableHotels()
        {
            _subject.GetHotels();

            A.CallTo(() => _hotelSystemDouble.GetHotels()).MustHaveHappened();
        }

        [Test]
        public void ShouldReturnCurrentHotelsInHotelSystem()
        {
            var dummyHotels = new ReadOnlyCollection<Hotel>(new List<Hotel>());
            A.CallTo(() => _hotelSystemDouble.GetHotels()).Returns(dummyHotels);

            _subject.GetHotels().Should().Equals(dummyHotels);
        }
    }
}
