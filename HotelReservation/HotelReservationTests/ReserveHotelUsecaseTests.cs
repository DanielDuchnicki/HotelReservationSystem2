using HotelReservation.Hotels;
using System.Collections.ObjectModel;
using NUnit.Framework;
using FakeItEasy;
using System.Collections.Generic;
using HotelReservation;

namespace HotelReservationTests
{
    [TestFixture]
    class ReserveHotelUsecaseTests
    {
        ReserveHotelUsecase _subject;
        HotelSystem _hotelSystemDouble;
        

        [SetUp]
        public void BeforeTest()
        {
            _hotelSystemDouble = A.Fake<HotelSystem>();
            _subject = new ReserveHotelUsecase(_hotelSystemDouble);
        }

        [Test]
        public void GetHotelsShouldCallHotelSystemGetHotels()
        {
            _subject.GetHotels();

            A.CallTo(() => _hotelSystemDouble.GetHotels()).MustHaveHappened();
        }

        [Test]
        public void GetHotelReservationStepsShouldCallHotelSystemGetHotelReservationSteps()
        {
            var dummyHotelId = 1;

            _subject.GetHotelReservationSteps(dummyHotelId);

            A.CallTo(() => _hotelSystemDouble.GetHotelReservationSteps(dummyHotelId)).MustHaveHappened();
        }
    }
}
