using FluentAssertions;
using HotelReservation.ReservationSteps;
using HotelReservation.ReservationSteps.Mail;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace HotelReservationTests.ReservationSteps.Mail
{
    [TestFixture]
    public class SendingMailProcessTests
    {
        private SendingMailProcess _subject;

        [SetUp]
        public void BeforeTest()
        {
            _subject = new SendingMailProcess();
        }

        [Test]
        public void ShouldProvideSendingMailProcessInputs()
        {
            var stepInputs = new List<StepInput> { new StepInput(InputType.Name),
                new StepInput(InputType.EmailAddress) };

            _subject.GetRequiredStepInputs().Should().BeEquivalentTo(stepInputs);
        }
        
        [Test]
        public void ShouldThrowExceptionWhenNameInputIsMissing()
        {
            const InputType unexpectedInputType = (InputType)(-1);
            var incorrectStepInput = new StepInput(unexpectedInputType);

            Action act = () => _subject.Execute(new List<StepInput> { incorrectStepInput });
            act.Should().Throw<NullReferenceException>().WithMessage("StepInput hasn't been correctly set!");
        }

        [Test]
        public void ShouldReturnStepOutputWithEmptyIncorrectStepsInputsForCorrectStepInput()
        {
            const string nameValue = "Test name value";
            const string mailValue = "Test mail value";
            var name = new StepInput(InputType.Name) { Value = nameValue };
            var mail = new StepInput(InputType.EmailAddress) { Value = mailValue };

            var stepOutput = _subject.Execute(new List<StepInput> { name, mail });

            stepOutput.IncorrectInputsTypes.Should().BeEmpty();
        }

        [Test]
        public void ShouldReturnStepOutputWithExpectedIncorrectInputTypesForEmptyStepInput()
        {
            const string nameValue = "";
            const string mailValue = "Test mail value";
            var name = new StepInput(InputType.Name) { Value = nameValue };
            var mail = new StepInput(InputType.EmailAddress) { Value = mailValue };
            var expectedIncorrectStepInputTypes = new List<InputType> { InputType.Name };

            var stepOutput = _subject.Execute(new List<StepInput> { name, mail });

            stepOutput.IncorrectInputsTypes.Should().BeEquivalentTo(expectedIncorrectStepInputTypes);
        }
    }
}
