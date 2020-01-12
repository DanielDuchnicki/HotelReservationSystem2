﻿using FakeItEasy;
using FluentAssertions;
using HotelReservation;
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
        private ConsolePrinter _consolePrinterDouble;
        private StepInput _name;
        private StepInput _mail;

        [SetUp]
        public void BeforeTest()
        {
            _consolePrinterDouble = A.Fake<ConsolePrinter>();
            _subject = new SendingMailProcess(_consolePrinterDouble);
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
        public void ExecuteShouldCallConsolePrinterWithStepName()
        {
            _subject.Execute(new List<StepInput> { _name, _mail });

            A.CallTo(() => _consolePrinterDouble.Write("----==== SENDING MAIL PROCESS ====----")).MustHaveHappened();
        }

        [Test]
        public void ShouldCallConsolePrinterWithProvidedNameValue()
        {
            const string nameValue = "Test name value";
            _name.Value = nameValue;

            _subject.Execute(new List<StepInput> { _name, _mail });

            A.CallTo(() => _consolePrinterDouble.Write(nameValue)).MustHaveHappened();
        }

        [Test]
        public void ShouldCallConsolePrinterWithProvidedMailValue()
        {
            const string mailValue = "Test mail value";
            _mail.Value = mailValue;

            _subject.Execute(new List<StepInput> { _name, _mail });

            A.CallTo(() => _consolePrinterDouble.Write(mailValue)).MustHaveHappened();
        }

        [Test]
        public void ShouldThrowExceptionWhenNameInputIsMissing()
        {
            const InputType unexpectedInputType = (InputType)(-1);
            var incorrectStepInput = new StepInput(unexpectedInputType);

            Action act = () => _subject.Execute(new List<StepInput> { incorrectStepInput });
            act.Should().Throw<NullReferenceException>().WithMessage("StepInput hasn't been correctly set!");
        }
    }
}
