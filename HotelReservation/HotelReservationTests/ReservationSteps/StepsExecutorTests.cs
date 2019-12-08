using System.Collections.Generic;
using FakeItEasy;
using HotelReservation.ReservationSteps;
using NUnit.Framework;
using HotelReservation.ReservationSteps.Reservation;
using HotelReservation;
using HotelReservation.ReservationSteps.Payment;
using HotelReservation.ReservationSteps.Mail;

namespace HotelReservationTests.ReservationSteps
{
    [TestFixture]
    class StepsExecutorTests
    {
        private StepsExecutor _subject;
        private List<StepInput> _stepInputList;
        private ConsolePrinter _consolePrinterDouble;

        [SetUp]
        public void BeforeTest()
        {
            _subject = new StepsExecutor();
            _stepInputList = new List<StepInput>();
            _consolePrinterDouble = A.Fake<ConsolePrinter>();
        }

        [Test]
        public void ShouldExecuteCreatedStep()
        {
            var stepDouble = A.Fake<IReservationStep>();

            _subject.ExecuteSteps(new List<IReservationStep> { stepDouble }, _stepInputList);

            A.CallTo(() => stepDouble.Execute(_stepInputList)).MustHaveHappened();
        }

        [Test]
        public void ShouldExecuteReservationStartProcessStep()
        {
            var reservationStartProcessStepDouble = A.Fake<ReservationStartProcess>();
            A.CallTo(() => reservationStartProcessStepDouble.Execute(_stepInputList)).DoesNothing();

            _subject.ExecuteSteps(new List<IReservationStep> { reservationStartProcessStepDouble }, _stepInputList);

            A.CallTo(() => reservationStartProcessStepDouble.Execute(_stepInputList)).MustHaveHappened();
        }

        [Test]
        public void ShouldExecutePaymentProcessStep()
        {
            var PaymentProcessStepDouble = A.Fake<PaymentProcess>();
            A.CallTo(() => PaymentProcessStepDouble.Execute(_stepInputList)).DoesNothing();

            _subject.ExecuteSteps(new List<IReservationStep> { PaymentProcessStepDouble }, _stepInputList);

            A.CallTo(() => PaymentProcessStepDouble.Execute(_stepInputList)).MustHaveHappened();
        }

        [Test]
        public void ShouldExecuteSendingMailStep()
        {
            var SendingMailProcessStepDouble = A.Fake<SendingMailProcess>();
            A.CallTo(() => SendingMailProcessStepDouble.Execute(_stepInputList)).DoesNothing();

            _subject.ExecuteSteps(new List<IReservationStep> { SendingMailProcessStepDouble }, _stepInputList);

            A.CallTo(() => SendingMailProcessStepDouble.Execute(_stepInputList)).MustHaveHappened();
        }

        [Test]
        public void ShouldExecuteThreeCreatedSteps()
        {
            var StepDouble = A.Fake<IReservationStep>();

            var providedListOfSteps = new List<IReservationStep> { StepDouble, StepDouble, StepDouble};

            _subject.ExecuteSteps(providedListOfSteps, _stepInputList);

            A.CallTo(() => StepDouble.Execute(_stepInputList)).MustHaveHappened(3, Times.Exactly);
        }

        [Test]
        public void ShouldExecuteThreeRealSteps()
        {
            var reservationStartProcessStepDouble = A.Fake<ReservationStartProcess>();
            A.CallTo(() => reservationStartProcessStepDouble.Execute(_stepInputList)).DoesNothing();
            var PaymentProcessStepDouble = A.Fake<PaymentProcess>();
            A.CallTo(() => PaymentProcessStepDouble.Execute(_stepInputList)).DoesNothing();
            var SendingMailProcessStepDouble = A.Fake<SendingMailProcess>();
            A.CallTo(() => SendingMailProcessStepDouble.Execute(_stepInputList)).DoesNothing();

            _subject.ExecuteSteps(new List<IReservationStep> { reservationStartProcessStepDouble, PaymentProcessStepDouble, SendingMailProcessStepDouble }, _stepInputList);

            A.CallTo(() => reservationStartProcessStepDouble.Execute(_stepInputList)).MustHaveHappened();
            A.CallTo(() => PaymentProcessStepDouble.Execute(_stepInputList)).MustHaveHappened();
            A.CallTo(() => SendingMailProcessStepDouble.Execute(_stepInputList)).MustHaveHappened();
        }
    }
}
