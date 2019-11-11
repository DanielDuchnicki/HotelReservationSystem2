using System.Collections.Generic;
using FakeItEasy;
using HotelReservation.ReservationSteps;
using NUnit.Framework;
using HotelReservation;

namespace HotelReservationTests.ReservationSteps
{
    [TestFixture]
    class StepsExecutorTests
    {
        private StepsExecutor _subject;
        private StepFactory _stepFactoryDouble;
        private ConsolePrinter _consolePrinter;
        private List<StepInput> _stepInputList;

        [SetUp]
        public void BeforeTest()
        {
            _stepFactoryDouble = A.Fake<StepFactory>();
            _subject = new StepsExecutor(_stepFactoryDouble);
            _consolePrinter = new ConsolePrinter();
            _stepInputList = new List<StepInput> { };
        }

        [Test]
        public void ShouldExecuteCreatedStep()
        {
            var stepDouble = A.Fake<IReservationStep>();

            A.CallTo(() => _stepFactoryDouble.CreateInstance(A<ReservationStepType>._)).Returns(stepDouble);

            _subject.ExecuteSteps(new List<ReservationStepType> { (ReservationStepType)(-1) }, _consolePrinter, _stepInputList);

            A.CallTo(() => stepDouble.Execute(_consolePrinter, _stepInputList)).MustHaveHappened();
        }

        [Test]
        public void ShouldCreateStepBasedOnProvidedType()
        {
            var providedType = ReservationStepType.PaymentProcess;

            _subject.ExecuteSteps(new List<ReservationStepType> { providedType }, _consolePrinter, _stepInputList);

            A.CallTo(() => _stepFactoryDouble.CreateInstance(providedType)).MustHaveHappened();
        }

        [Test]
        public void ShouldExecuteThreeCreatedSteps()
        {
            var StepDouble = A.Fake<IReservationStep>();

            A.CallTo(() => _stepFactoryDouble.CreateInstance(A<ReservationStepType>._)).Returns(StepDouble);

            var providedListOfSteps = new List<ReservationStepType> {
                (ReservationStepType)(-1), (ReservationStepType)(-1), (ReservationStepType)(-1) };

            _subject.ExecuteSteps(providedListOfSteps, _consolePrinter, _stepInputList);

            A.CallTo(() => StepDouble.Execute(_consolePrinter, _stepInputList)).MustHaveHappened(3, Times.Exactly);
        }

        [Test]
        public void ShouldCreateStepsBasedOnProvidedListOfStepsTypes()
        {
            var providedListOfTypes = new List<ReservationStepType> {
                ReservationStepType.PaymentProcess, ReservationStepType.SendingMailProcess };

            _subject.ExecuteSteps(providedListOfTypes, _consolePrinter, _stepInputList);

            A.CallTo(() => _stepFactoryDouble.CreateInstance(providedListOfTypes[0])).MustHaveHappened();
            A.CallTo(() => _stepFactoryDouble.CreateInstance(providedListOfTypes[1])).MustHaveHappened();
        }
    }
}
