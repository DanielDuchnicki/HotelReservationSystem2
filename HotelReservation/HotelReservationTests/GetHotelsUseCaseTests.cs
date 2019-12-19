using HotelReservation.Hotels;
using NUnit.Framework;
using FakeItEasy;
using System.Collections.Generic;
using HotelReservation;
using HotelReservation.ReservationSteps;

namespace HotelReservationTests
{
    class GetHotelsUseCaseTests
    {
        GetHotelsUseCase _subject;
        HotelSystem _hotelSystemDouble;

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
    }
}
