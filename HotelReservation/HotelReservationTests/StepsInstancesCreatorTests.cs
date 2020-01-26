using FakeItEasy;
using FluentAssertions;
using HotelReservation;
using HotelReservation.ReservationSteps;
using HotelReservation.ReservationSteps.Payment;
using HotelReservation.ReservationSteps.Reservation;
using NUnit.Framework;
using System.Collections.Generic;

namespace HotelReservationTests
{
    [TestFixture]
    public class StepsInstancesCreatorTests
    {
        private StepsInstancesCreator _subject;
        private StepFactory _stepFactoryDouble;

        [SetUp]
        public void BeforeTest()
        {
            _stepFactoryDouble = A.Fake<StepFactory>();
            _subject = new StepsInstancesCreator(_stepFactoryDouble);
        }

        [Test]
        public void ShouldCreateStep()
        {
            const ReservationStepType dummyStepType = (ReservationStepType)(-1);

            _subject.Execute(new List<ReservationStepType> { dummyStepType });

            A.CallTo(() => _stepFactoryDouble.CreateInstance(dummyStepType)).MustHaveHappened();
        }

        [Test]
        public void ShouldCreateRealStepsForProvidedListOfReservationStepTypes()
        {
            var dummyStepTypes = new List<ReservationStepType> { ReservationStepType.PaymentProcess, ReservationStepType.ReservationProcess };

            var firstStepDouble = new PaymentProcess();
            var secondStepDouble = new ReservationStartProcess();

            A.CallTo(() => _stepFactoryDouble.CreateInstance(ReservationStepType.PaymentProcess)).Returns(firstStepDouble);
            A.CallTo(() => _stepFactoryDouble.CreateInstance(ReservationStepType.ReservationProcess)).Returns(secondStepDouble);

            var expectedStepsInstances = new List<IReservationStep> { firstStepDouble, secondStepDouble };

            _subject.Execute(dummyStepTypes).Should().Equal(expectedStepsInstances);
        }
    }
}
