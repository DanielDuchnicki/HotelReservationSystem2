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
            var stepDouble = A.Fake<IReservationStep>();

            A.CallTo(() => _hotelSystemDouble.GetHotelReservationSteps(A<int>._)).Returns((new List<ReservationStepType> { (ReservationStepType)(-1) }));
            A.CallTo(() => _stepFactoryDouble.CreateInstance(A<ReservationStepType>._)).Returns(stepDouble);

            _subject.ReserveHotel(dummyHotelId, stepInputsDouble);

            A.CallTo(() => _stepExecutorDouble.ExecuteSteps(
                A<List<IReservationStep>>.That.Matches(steps => steps.Contains(stepDouble)), stepInputsDouble)).MustHaveHappened();
        }

        [Test]
        public void ShouldReturnFailedReservationResult()
        {
            const int dummyHotelId = 1;
            var stepInputsDouble = new List<StepInput> {A.Fake<StepInput>()};
            var stepOutputDouble = new StepOutput(new List<InputType> { (InputType)(-1) });

            A.CallTo(() => _stepExecutorDouble.ExecuteSteps(A<List<IReservationStep>>._, A<List<StepInput>>._)).Returns(new List<StepOutput> { stepOutputDouble });

            var reservationResult = _subject.ReserveHotel(dummyHotelId, stepInputsDouble);

            reservationResult.IsSuccessful.Should().BeFalse();
        }

        [Test]
        public void ShouldReturnSuccessfulReservationResult()
        {
            const int dummyHotelId = 1;
            var stepInputsDouble = new List<StepInput> { A.Fake<StepInput>() };
            var stepOutputDouble = new StepOutput(new List<InputType>());

            A.CallTo(() => _stepExecutorDouble.ExecuteSteps(A<List<IReservationStep>>._, A<List<StepInput>>._)).Returns(new List<StepOutput> { stepOutputDouble });

            var reservationResult = _subject.ReserveHotel(dummyHotelId, stepInputsDouble);

            reservationResult.IsSuccessful.Should().BeTrue();
        }

        [Test]
        public void ShouldReturnReservationResultWithIncorrectInputTypes()
        {
            const int dummyHotelId = 1;
            var stepInputsDouble = new List<StepInput> { A.Fake<StepInput>() };
            var incorrectInputTypesDouble = new List<InputType> {(InputType) (-1)};
            var stepOutputDouble = new StepOutput(incorrectInputTypesDouble);

            A.CallTo(() => _stepExecutorDouble.ExecuteSteps(A<List<IReservationStep>>._, A<List<StepInput>>._)).Returns(new List<StepOutput> { stepOutputDouble });

            var reservationResult = _subject.ReserveHotel(dummyHotelId, stepInputsDouble);

            reservationResult.IncorrectInputTypes.Should().BeEquivalentTo(new ReadOnlyCollection<InputType>(incorrectInputTypesDouble));
        }

        [Test]
        public void ShouldReturnReservationResultWithEmptyIncorrectInputTypes()
        {
            const int dummyHotelId = 1;
            var stepInputsDouble = new List<StepInput> { A.Fake<StepInput>() };
            var stepOutputDouble = new StepOutput(new List<InputType>( ));

            A.CallTo(() => _stepExecutorDouble.ExecuteSteps(A<List<IReservationStep>>._, A<List<StepInput>>._)).Returns(new List<StepOutput> { stepOutputDouble });

            var reservationResult = _subject.ReserveHotel(dummyHotelId, stepInputsDouble);

            reservationResult.IncorrectInputTypes.Should().BeEmpty();
        }
    }
}
