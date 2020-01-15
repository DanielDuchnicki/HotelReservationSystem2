using System.Collections.Generic;
using FakeItEasy;
using FluentAssertions;
using HotelReservation.ReservationSteps;
using NUnit.Framework;
using HotelReservation.ReservationSteps.Reservation;
using HotelReservation.ReservationSteps.Payment;
using HotelReservation.ReservationSteps.Mail;

namespace HotelReservationTests.ReservationSteps
{
    [TestFixture]
    public class StepsExecutorTests
    {
        private StepsExecutor _subject;
        private List<StepInput> _stepInputList;

        [SetUp]
        public void BeforeTest()
        {
            _subject = new StepsExecutor();
            _stepInputList = new List<StepInput>();
        }

        [Test]
        public void ShouldExecuteCreatedStep()
        {
            var stepDouble = A.Fake<IReservationStep>();

            _subject.ExecuteSteps(new List<IReservationStep> { stepDouble }, _stepInputList);

            A.CallTo(() => stepDouble.Execute(_stepInputList)).MustHaveHappened();
        }

        [Test]
        public void ShouldExecuteRealStepAndReturnStepOutputs()
        {
            var reservationStartProcessStepDouble = A.Fake<ReservationStartProcess>();
            var stepOutputDouble = new StepOutput(true, "message");
            var expectedStepOutputs = new List<StepOutput> { stepOutputDouble };

            A.CallTo(() => reservationStartProcessStepDouble.Execute(_stepInputList)).Returns(stepOutputDouble);

            var stepOutputs = _subject.ExecuteSteps(new List<IReservationStep> { reservationStartProcessStepDouble }, _stepInputList);

            stepOutputs.Should().BeEquivalentTo(expectedStepOutputs);
        }

        [Test]
        public void ShouldExecuteThreeCreatedSteps()
        {
            var stepDouble = A.Fake<IReservationStep>();

            var providedListOfSteps = new List<IReservationStep> { stepDouble, stepDouble, stepDouble };

            _subject.ExecuteSteps(providedListOfSteps, _stepInputList);

            A.CallTo(() => stepDouble.Execute(_stepInputList)).MustHaveHappened(3, Times.Exactly);
        }

        [Test]
        public void ShouldExecuteThreeRealStepsAndReturnStepOutputs()
        {
            var reservationStartProcessStepDouble = A.Fake<ReservationStartProcess>();
            var paymentProcessStepDouble = A.Fake<PaymentProcess>();
            var sendingMailProcessStepDouble = A.Fake<SendingMailProcess>();

            var stepOutputDouble = new StepOutput(true, "message");
            var stepOutputDouble2 = new StepOutput(false, "message2");
            var expectedStepOutputs = new List<StepOutput> {stepOutputDouble, stepOutputDouble, stepOutputDouble2};

            A.CallTo(() => reservationStartProcessStepDouble.Execute(_stepInputList)).Returns(stepOutputDouble);
            A.CallTo(() => paymentProcessStepDouble.Execute(_stepInputList)).Returns(stepOutputDouble);
            A.CallTo(() => sendingMailProcessStepDouble.Execute(_stepInputList)).Returns(stepOutputDouble2);

            var stepOutputs = _subject.ExecuteSteps(
                new List<IReservationStep> { reservationStartProcessStepDouble, paymentProcessStepDouble, sendingMailProcessStepDouble }, _stepInputList);

            stepOutputs.Should().BeEquivalentTo(expectedStepOutputs);
        }
    }
}
