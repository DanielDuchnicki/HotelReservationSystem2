using HotelReservation.Hotels;
using NUnit.Framework;
using FakeItEasy;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using FluentAssertions;
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
            const int dummyHotelId = 1;
            var stepInputsDouble = new List<StepInput>();

            _subject.ReserveHotel(dummyHotelId, stepInputsDouble);

            A.CallTo(() => _hotelSystemDouble.GetHotelReservationSteps(dummyHotelId)).MustHaveHappened();
        }


        [Test]
        public void ShouldExecuteStepsForProvidedHotelId()
        {
            const int dummyHotelId = 1;
            var stepInputsDouble = new List<StepInput> { A.Fake<StepInput>() };
            var stepsOutputsDouble = new List<StepOutput> { A.Fake<StepOutput>() };

            A.CallTo(() => _stepExecutorDouble.ExecuteSteps(A<List<IReservationStep>>._, A<List<StepInput>>._))
                .Returns(stepsOutputsDouble);

            var stepOutputs = _subject.ReserveHotel(dummyHotelId, stepInputsDouble);

            stepOutputs.Should().BeEquivalentTo(new ReadOnlyCollection<StepOutput>(stepsOutputsDouble));
        }
    }
}
