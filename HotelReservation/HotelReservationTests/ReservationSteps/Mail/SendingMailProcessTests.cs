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
        public void ShouldReturnStepOutputWithSuccessfulResultForCorrectStepInput()
        {
            const string mailValue = "Test mail value";
            var name = new StepInput(InputType.Name);
            var mail = new StepInput(InputType.EmailAddress) {Value = mailValue};

            var stepOutput = _subject.Execute(new List<StepInput> { name, mail });

            stepOutput.IsSuccessful.Should().BeTrue();
        }

        [Test]
        public void ShouldReturnStepOutputWithCertainMessageForCorrectStepInput()
        {
            const string nameValue = "Test name value";
            const string mailValue = "Test mail value";
            const string message = "Your name: " + nameValue + "\nYour mail: " + mailValue + "\nSending mail step finished with success!";
            var name = new StepInput(InputType.Name) {Value = nameValue};
            var mail = new StepInput(InputType.EmailAddress) {Value = mailValue};

            var stepOutput = _subject.Execute(new List<StepInput> { name, mail });

            stepOutput.Message.Should().Be(message);
        }

        [Test]
        public void ShouldReturnStepOutputWithNotSuccessfulResultForEmptyStepInput()
        {
            const string mailValue = "";
            var name = new StepInput(InputType.Name);
            var mail = new StepInput(InputType.EmailAddress) {Value = mailValue};

            var stepOutput = _subject.Execute(new List<StepInput> { name, mail });

            stepOutput.IsSuccessful.Should().BeFalse();
        }

        [Test]
        public void ShouldReturnStepOutputWithCertainMessageForEmptyStepInput()
        {
            const string mailValue = "";
            const string message = "Your provided incorrect mail";
            var name = new StepInput(InputType.Name);
            var mail = new StepInput(InputType.EmailAddress) {Value = mailValue};

            var stepOutput = _subject.Execute(new List<StepInput> { name, mail });

            stepOutput.Message.Should().Be(message);
        }
    }
}
