using System.Collections.Generic;
using FakeItEasy;
using HotelReservation.ReservationSteps;
using NUnit.Framework;
using HotelReservation.ReservationSteps.Reservation;
using HotelReservation.ReservationSteps.Payment;
using HotelReservation.ReservationSteps.Mail;

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
            var stepDataDouble = A.Fake<IStepData>();
            stepDataDouble.ReservationStep = (ReservationStepType)(-1);

            A.CallTo(() => _stepFactoryDouble.CreateInstance(A<ReservationStepType>._)).Returns(stepDouble);

            _subject.ExecuteSteps(new List<ReservationStepType> { (ReservationStepType)(-1) }, new List<IStepData> { stepDataDouble });

            A.CallTo(() => stepDouble.Execute(stepDataDouble)).MustHaveHappened();
        }

        [Test]
        public void ShouldCreateStepBasedOnProvidedType()
        {
            var providedType = ReservationStepType.PaymentProcess;
            var stepData = new ReservationStartProcessData(1);

            _subject.ExecuteSteps(new List<ReservationStepType> { providedType }, new List<IStepData> { stepData });

            A.CallTo(() => _stepFactoryDouble.CreateInstance(providedType)).MustHaveHappened();
        }

        [Test]
        public void ShouldExecuteThreeCreatedSteps()
        {
            var StepDouble = A.Fake<IReservationStep>();
            var stepDataDouble = A.Fake<IStepData>();
            stepDataDouble.ReservationStep = (ReservationStepType)(-1);

            A.CallTo(() => _stepFactoryDouble.CreateInstance(A<ReservationStepType>._)).Returns(StepDouble);

            var providedListOfSteps = new List<ReservationStepType> {
                (ReservationStepType)(-1), (ReservationStepType)(-1), (ReservationStepType)(-1) };

            _subject.ExecuteSteps(providedListOfSteps, new List<IStepData> { stepDataDouble });

            A.CallTo(() => StepDouble.Execute(stepDataDouble)).MustHaveHappened(3, Times.Exactly);
        }

        [Test]
        public void ShouldCreateStepsBasedOnProvidedListOfStepsTypes()
        {
            var providedListOfTypes = new List<ReservationStepType> {
                ReservationStepType.PaymentProcess, ReservationStepType.SendingMailProcess };
            var stepsData = new List<IStepData> { new PaymentProcessData(20), new SendingMailProcessData("mail@mail.com") };

            _subject.ExecuteSteps(providedListOfTypes, stepsData);

            A.CallTo(() => _stepFactoryDouble.CreateInstance(providedListOfTypes[0])).MustHaveHappened();
            A.CallTo(() => _stepFactoryDouble.CreateInstance(providedListOfTypes[1])).MustHaveHappened();
        }
    }
}
