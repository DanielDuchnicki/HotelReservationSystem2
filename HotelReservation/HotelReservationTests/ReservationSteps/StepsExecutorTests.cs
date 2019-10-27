using System.Collections.Generic;
using FakeItEasy;
using HotelReservation.ReservationSteps;
using NUnit.Framework;
using HotelReservation.ReservationSteps.Payment;
using HotelReservation.ReservationSteps.Hotel;

namespace HotelReservationTests.ReservationSteps
{
    [TestFixture]
    class StepsExecutorTests
    {
        private StepsExecutor _subject;
        private StepFactory _stepFactoryDouble;

        [SetUp]
        public void BeforeTest()
        {
            _stepFactoryDouble = A.Fake<StepFactory>();
            _subject = new StepsExecutor(_stepFactoryDouble);
        }

        [Test]
        public void ShouldExecuteCreatedStep()
        {
            var stepDouble = A.Fake<IReservationStep>();

            A.CallTo(() => _stepFactoryDouble.CreateInstance(A<ReservationStepType>._)).Returns(stepDouble);

            _subject.ExecuteSteps(new List<ReservationStepType> { (ReservationStepType)(-1) });

            A.CallTo(() => stepDouble.Execute()).MustHaveHappened();
        }

        [Test]
        public void ShouldCreateStepBasedOnProvidedType()
        {
            var providedType = ReservationStepType.PaymentProcess;

            _subject.ExecuteSteps(new List<ReservationStepType> { providedType });

            A.CallTo(() => _stepFactoryDouble.CreateInstance(providedType)).MustHaveHappened();
        }

        [Test]
        public void ShouldExecuteThreeCreatedSteps()
        {
            var StepDouble = A.Fake<IReservationStep>();

            A.CallTo(() => _stepFactoryDouble.CreateInstance(A<ReservationStepType>._)).Returns(StepDouble);

            var providedListOfSteps = new List<ReservationStepType> {
                (ReservationStepType)(-1), (ReservationStepType)(-1), (ReservationStepType)(-1) };

            _subject.ExecuteSteps(providedListOfSteps);

            A.CallTo(() => StepDouble.Execute()).MustHaveHappened(3, Times.Exactly);
        }

        [Test]
        public void ShouldCreateStepsBasedOnProvidedListOfStepsTypes()
        {
            var providedListOfTypes = new List<ReservationStepType> {
                ReservationStepType.PaymentProcess, ReservationStepType.SendingMailProcess };

            _subject.ExecuteSteps(providedListOfTypes);

            A.CallTo(() => _stepFactoryDouble.CreateInstance(providedListOfTypes[0])).MustHaveHappened();
            A.CallTo(() => _stepFactoryDouble.CreateInstance(providedListOfTypes[1])).MustHaveHappened();
        }
    }
}
