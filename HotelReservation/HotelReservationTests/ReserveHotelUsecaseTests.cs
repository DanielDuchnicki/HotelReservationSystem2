using HotelReservation.Hotels;
using NUnit.Framework;
using FakeItEasy;
using System.Collections.Generic;
using HotelReservation;
using HotelReservation.ReservationSteps;

namespace HotelReservationTests
{
    [TestFixture]
    class ReserveHotelUsecaseTests
    {
        ReserveHotelUsecase _subject;
        HotelSystem _hotelSystemDouble;
        StepFactory _stepFactoryDouble;
        StepsExecutor _stepExecutorDouble;

        [SetUp]
        public void BeforeTest()
        {
            _hotelSystemDouble = A.Fake<HotelSystem>();
            _stepFactoryDouble = A.Fake<StepFactory>();
            _stepExecutorDouble = A.Fake<StepsExecutor>();
            _subject = new ReserveHotelUsecase(_hotelSystemDouble, _stepFactoryDouble, _stepExecutorDouble);
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

        [Test]
        public void ShouldCreateStepBasedOnProvidedType()
        {
            var providedType = ReservationStepType.PaymentProcess;

            _subject.CreateStepsInstances(new List<ReservationStepType> { providedType });

            A.CallTo(() => _stepFactoryDouble.CreateInstance(providedType)).MustHaveHappened();
        }

        [Test]
        public void ShouldCreateStepsBasedOnProvidedListOfStepsTypes()
        {
            var providedListOfTypes = new List<ReservationStepType> {
                ReservationStepType.PaymentProcess, ReservationStepType.SendingMailProcess };

            _subject.CreateStepsInstances(providedListOfTypes);

            A.CallTo(() => _stepFactoryDouble.CreateInstance(providedListOfTypes[0])).MustHaveHappened();
            A.CallTo(() => _stepFactoryDouble.CreateInstance(providedListOfTypes[1])).MustHaveHappened();
        }

        [Test]
        public void ShouldCallStepGetHotelsMethod()
        {
            IReservationStep reservationStepDouble = A.Fake<IReservationStep>();

            _subject.GetStepsInputs(new List<IReservationStep> { reservationStepDouble });

            A.CallTo(() => reservationStepDouble.GetStepInputs()).MustHaveHappened();
        }

        [Test]
        public void ShouldCallStepExecutorExecuteSteps()
        {
            IReservationStep reservationStepDouble = A.Fake<IReservationStep>();
            StepInput stepInputDouble = A.Fake<StepInput>();

            List<IReservationStep> reservationStepsDouble = new List<IReservationStep> { reservationStepDouble };
            List<StepInput> stepInputsDouble = new List<StepInput> { stepInputDouble };

            _subject.ExecuteSteps(reservationStepsDouble, stepInputsDouble);

            A.CallTo(() => _stepExecutorDouble.ExecuteSteps(reservationStepsDouble, stepInputsDouble)).MustHaveHappened();
        }
    }
}
