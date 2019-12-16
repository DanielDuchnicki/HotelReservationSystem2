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
    class SendingMailProcessTests
    {
        SendingMailProcess _subject;
        ConsolePrinter _consolePrinterDouble;
        StepInput _name;
        StepInput _mail;

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
        public void ShouldCallConsolePrinterWithProvidedArgument()
        {
            const string nameValue = "Test name value";
            const string mailValue = "Test mail value";

            _name.Value = nameValue;
            _mail.Value = mailValue;

            _subject.Execute(new List<StepInput> { _name, _mail });

            A.CallTo(() => _consolePrinterDouble.Write(nameValue)).MustHaveHappened();
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
