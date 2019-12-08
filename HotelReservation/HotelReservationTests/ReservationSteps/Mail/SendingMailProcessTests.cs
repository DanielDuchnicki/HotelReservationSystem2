using FakeItEasy;
using FluentAssertions;
using HotelReservation;
using HotelReservation.ReservationSteps;
using HotelReservation.ReservationSteps.Mail;
using NUnit.Framework;
using System.Collections.Generic;

namespace HotelReservationTests.ReservationSteps.Mail
{
    [TestFixture]
    class SendingMailProcessTests
    {
        SendingMailProcess _subject;
        ConsolePrinter _consolePrinterDouble;
        StepInput _name;
        StepInput _email;

        [SetUp]
        public void BeforeTest()
        {
            _consolePrinterDouble = A.Fake<ConsolePrinter>();
            _subject = new SendingMailProcess(_consolePrinterDouble);
            _name = new StepInput(InputType.Name);
            _email = new StepInput(InputType.EmailAddress);
        }

        [Test]
        public void ShouldProvideSendingMailProcessInputs()
        {
            var stepInputs = new List<StepInput> { _name, _email };

            _subject.GetStepInputs().Should().BeEquivalentTo(stepInputs);
        }

        [Test]
        public void ExecuteShouldCallConsolePrinterWithStepName()
        {
            _subject.Execute(new List<StepInput>());

            A.CallTo(() => _consolePrinterDouble.Write("----==== SENDING MAIL PROCESS ====----")).MustHaveHappened();
        }
    }
}
