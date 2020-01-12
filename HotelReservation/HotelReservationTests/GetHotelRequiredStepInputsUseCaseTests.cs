using HotelReservation.Hotels;
using NUnit.Framework;
using FakeItEasy;
using System.Collections.Generic;
using HotelReservation;
using HotelReservation.ReservationSteps;

namespace HotelReservationTests
{
    [TestFixture]
    public class GetHotelRequiredStepInputsUseCaseTests
    {
        private GetHotelRequiredStepInputsUseCase _subject;
        private HotelSystem _hotelSystemDouble;
        private StepFactory _stepFactoryDouble;

        [SetUp]
        public void BeforeTest()
        {
            _hotelSystemDouble = A.Fake<HotelSystem>();
            _stepFactoryDouble = A.Fake<StepFactory>();
            _subject = new GetHotelRequiredStepInputsUseCase(_hotelSystemDouble, _stepFactoryDouble);
        }

        [Test]
        public void ShouldRetrieveHotelReservationStepsForProvidedHotelId()
        {
            const int dummyHotelId = 1;

            _subject.GetRequiredStepInputsForHotelId(dummyHotelId);

            A.CallTo(() => _hotelSystemDouble.GetHotelReservationSteps(dummyHotelId)).MustHaveHappened();
        }


        [Test]
        public void ShouldRetrieveRequiredStepInputs()
        {
            const int dummyHotelId = 1;
            var stepDouble = A.Fake<IReservationStep>();

            A.CallTo(() => _hotelSystemDouble.GetHotelReservationSteps(A<int>._)).Returns((new List<ReservationStepType> { (ReservationStepType)(-1) }));
            A.CallTo(() => _stepFactoryDouble.CreateInstance(A<ReservationStepType>._)).Returns(stepDouble);

            _subject.GetRequiredStepInputsForHotelId(dummyHotelId);

            A.CallTo(() => stepDouble.GetRequiredStepInputs()).MustHaveHappened();
        }

    }
}
