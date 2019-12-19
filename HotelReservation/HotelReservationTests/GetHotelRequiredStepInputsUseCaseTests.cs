using HotelReservation.Hotels;
using NUnit.Framework;
using FakeItEasy;
using System.Collections.Generic;
using HotelReservation;
using HotelReservation.ReservationSteps;

namespace HotelReservationTests
{
    [TestFixture]
    class GetHotelRequiredStepInputsUseCaseTests
    {
        GetHotelRequiredStepInputsUseCase _subject;
        HotelSystem _hotelSystemDouble;
        StepFactory _stepFactoryDouble;

        [SetUp]
        public void BeforeTest()
        {
            _hotelSystemDouble = A.Fake<HotelSystem>();
            _stepFactoryDouble = A.Fake<StepFactory>();
            _subject = new GetHotelRequiredStepInputsUseCase(_hotelSystemDouble, _stepFactoryDouble);
        }

        [Test]
        public void ShouldRetrieveHotelReservationSteps()
        {
            var dummyHotelId = 1;

            _subject.GetHotelReservationSteps(dummyHotelId);

            A.CallTo(() => _hotelSystemDouble.GetHotelReservationSteps(dummyHotelId)).MustHaveHappened();
        }

        [Test]
        public void ShouldRetrieveRequiredStepInputs()
        {
            IReservationStep reservationStepDouble = A.Fake<IReservationStep>();

            _subject.GetRequiredStepsInputs(new List<IReservationStep> { reservationStepDouble });

            A.CallTo(() => reservationStepDouble.GetRequiredStepInputs()).MustHaveHappened();
        }
    }
}
