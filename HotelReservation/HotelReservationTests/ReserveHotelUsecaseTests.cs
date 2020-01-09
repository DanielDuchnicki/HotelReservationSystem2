using HotelReservation.Hotels;
using NUnit.Framework;
using FakeItEasy;
using System.Collections.Generic;
using HotelReservation;
using HotelReservation.ReservationSteps;

namespace HotelReservationTests
{
    [TestFixture]
    public class ReserveHotelUsecaseTests
    {
        private ReserveHotelUsecase _subject;
        private HotelSystem _hotelSystemDouble;
        private StepFactory _stepFactoryDouble;
        private StepsExecutor _stepExecutorDouble;

        [SetUp]
        public void BeforeTest()
        {
            _hotelSystemDouble = A.Fake<HotelSystem>();
            _stepFactoryDouble = A.Fake<StepFactory>();
            _stepExecutorDouble = A.Fake<StepsExecutor>();
            _subject = new ReserveHotelUsecase(_hotelSystemDouble, _stepFactoryDouble, _stepExecutorDouble);
        }

        [Test]
        public void ShouldReserveHotelGetHotelReservationSteps()
        {
            var dummyHotelId = 1;
            var stepInputsDouble = new List<StepInput>();

            _subject.ReserveHotel(dummyHotelId, stepInputsDouble);

            A.CallTo(() => _hotelSystemDouble.GetHotelReservationSteps(dummyHotelId)).MustHaveHappened();
        }

        [Test]
        public void ShouldCreateStepForProvidedHotelId()
        {
            var dummyHotelId = 1;
            var stepInputsDouble = new List<StepInput>();

            A.CallTo(() => _hotelSystemDouble.GetHotelReservationSteps(A<int>._)).Returns((new List<ReservationStepType> { (ReservationStepType)(-1)}));

            _subject.ReserveHotel(dummyHotelId, stepInputsDouble);

            A.CallTo(() => _stepFactoryDouble.CreateInstance((ReservationStepType)(-1))).MustHaveHappened();
        }

        [Test]
        public void ShouldCreateRealStepsForProvidedHotelId()
        {
            var dummyHotelId = 1;
            var stepInputsDouble = new List<StepInput>();

            A.CallTo(() => _hotelSystemDouble.GetHotelReservationSteps(A<int>._)).
                Returns((new List<ReservationStepType> { ReservationStepType.PaymentProcess, ReservationStepType.ReservationProcess }));

            _subject.ReserveHotel(dummyHotelId, stepInputsDouble);

            A.CallTo(() => _stepFactoryDouble.CreateInstance(ReservationStepType.PaymentProcess)).MustHaveHappened();
            A.CallTo(() => _stepFactoryDouble.CreateInstance(ReservationStepType.ReservationProcess)).MustHaveHappened();
        }

        [Test]
        public void ShouldExecuteStepsForProvidedHotelId()
        {
            var dummyHotelId = 1;
            var stepInputsDouble = new List<StepInput> { A.Fake<StepInput>() };
            var stepDouble = A.Fake<IReservationStep>();

            A.CallTo(() => _hotelSystemDouble.GetHotelReservationSteps(A<int>._)).Returns((new List<ReservationStepType> { (ReservationStepType)(-1) }));
            A.CallTo(() => _stepFactoryDouble.CreateInstance(A<ReservationStepType>._)).Returns(stepDouble);

            _subject.ReserveHotel(dummyHotelId, stepInputsDouble);

            A.CallTo(() => _stepExecutorDouble.ExecuteSteps(
                A<List<IReservationStep>>.That.Matches(steps => steps.Contains(stepDouble)), stepInputsDouble)).MustHaveHappened();
        }
    }
}
