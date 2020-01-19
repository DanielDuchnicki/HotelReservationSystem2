﻿using FluentAssertions;
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
        private StepInput _name;
        private StepInput _mail;

        [SetUp]
        public void BeforeTest()
        {
            _subject = new SendingMailProcess();
            _name = new StepInput(InputType.Name);
            _mail = new StepInput(InputType.EmailAddress);
        }

        [Test]
        public void ShouldProvideSendingMailProcessInputs()
        {
            var stepInputs = new List<StepInput> { _name, _mail };

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
            _mail.Value = mailValue;

            var stepOutput = _subject.Execute(new List<StepInput> { _name, _mail });

            stepOutput.IsSuccessful.Should().BeTrue();
        }

        [Test]
        public void ShouldReturnStepOutputWithCertainMessageForCorrectStepInput()
        {
            const string nameValue = "Test name value";
            const string mailValue = "Test mail value";
            _name.Value = nameValue;
            _mail.Value = mailValue;
            const string message = "Your name: " + nameValue + "\nYour mail: " + mailValue + "\nSending mail step finished with success!";

            var stepOutput = _subject.Execute(new List<StepInput> { _name, _mail });

            stepOutput.Message.Should().Be(message);
        }

        [Test]
        public void ShouldReturnStepOutputWithNotSuccessfulResultForIncorrectStepInput()
        {
            const string mailValue = "";
            _mail.Value = mailValue;

            var stepOutput = _subject.Execute(new List<StepInput> { _name, _mail });

            stepOutput.IsSuccessful.Should().BeFalse();
        }

        [Test]
        public void ShouldReturnStepOutputWithCertainMessageForIncorrectStepInput()
        {
            const string mailValue = "";
            _mail.Value = mailValue;
            const string message = "Your provided incorrect mail";

            var stepOutput = _subject.Execute(new List<StepInput> { _name, _mail });

            stepOutput.Message.Should().Be(message);
        }
    }
}
