using System.Collections.Generic;
using System.Collections.ObjectModel;
using FakeItEasy;
using FluentAssertions;
using HotelReservation.ReservationSteps;
using NUnit.Framework;


namespace HotelReservationTests.ReservationSteps
{
    [TestFixture]
    public class StepsExecutorTests
    {
        private StepsExecutor _subject;
        private List<StepInput> _stepsInputs;

        [SetUp]
        public void BeforeTest()
        {
            _subject = new StepsExecutor();
            _stepsInputs = new List<StepInput>();
        }

        [Test]
        public void ShouldExecuteCreatedStepWithStepsInputs()
        {
            var stepDouble = A.Fake<IReservationStep>();

            _subject.ExecuteSteps(new List<IReservationStep> { stepDouble }, _stepsInputs);

            A.CallTo(() => stepDouble.Execute(_stepsInputs)).MustHaveHappened();
        }

        [Test]
        public void ShouldExecuteThreeCreatedStepsWithStepsInputs()
        {
            var stepDouble = A.Fake<IReservationStep>();

            var providedListOfSteps = new List<IReservationStep> { stepDouble, stepDouble, stepDouble };

            _subject.ExecuteSteps(providedListOfSteps, _stepsInputs);

            A.CallTo(() => stepDouble.Execute(_stepsInputs)).MustHaveHappened(3, Times.Exactly);
        }

        [Test]
        public void ShouldExecuteStepAndReturnStepOutputs()
        {
            var stepDouble = A.Fake<IReservationStep>();
            var stepOutputDouble = A.Fake<StepOutput>();
            var expectedStepOutputs = new List<StepOutput> { stepOutputDouble };

            A.CallTo(() => stepDouble.Execute(_stepsInputs)).Returns(stepOutputDouble);

            var stepOutputs = _subject.ExecuteSteps(new List<IReservationStep> { stepDouble }, _stepsInputs);

            stepOutputs.Should().BeEquivalentTo(expectedStepOutputs);
        }

        [Test]
        public void ShouldExecuteThreeStepsAndReturnStepOutputs()
        {
            var stepDouble = A.Fake<IReservationStep>();
            var stepDouble2 = A.Fake<IReservationStep>();
            var stepDouble3 = A.Fake<IReservationStep>();

            var stepOutputDouble = new StepOutput(null);
            var stepOutputDouble2 = new StepOutput(new List<InputType> { (InputType)(-1) });
            var stepOutputDouble3 = new StepOutput(new List<InputType> { (InputType)(-1), (InputType)(-1) });
            var expectedStepOutputs = new List<StepOutput> { stepOutputDouble, stepOutputDouble2, stepOutputDouble3 };

            A.CallTo(() => stepDouble.Execute(_stepsInputs)).Returns(stepOutputDouble);
            A.CallTo(() => stepDouble2.Execute(_stepsInputs)).Returns(stepOutputDouble2);
            A.CallTo(() => stepDouble3.Execute(_stepsInputs)).Returns(stepOutputDouble3);

            var stepOutputs = _subject.ExecuteSteps(
                new List<IReservationStep> { stepDouble, stepDouble2, stepDouble3 }, _stepsInputs);

            stepOutputs.Should().BeEquivalentTo(expectedStepOutputs);
        }
    }
}
