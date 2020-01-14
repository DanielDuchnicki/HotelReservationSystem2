using FakeItEasy;
using FluentAssertions;
using HotelReservation;
using HotelReservation.ReservationSteps;
using HotelReservation.ReservationSteps.Payment;
using NUnit.Framework;
using System.Collections.Generic;

namespace HotelReservationTests.ReservationSteps.Payment
{
    [TestFixture]
    public class PaymentProcessTests
    {
        private PaymentProcess _subject;
        private ConsolePrinter _consolePrinterDouble;

        [SetUp]
        public void BeforeTest()
        {
            _consolePrinterDouble = A.Fake<ConsolePrinter>();
            _subject = new PaymentProcess(_consolePrinterDouble);
        }

        [Test]
        public void ShouldProvidePaymentProcessInputs()
        {
            var stepInputs = new List<StepInput>();

            _subject.GetRequiredStepInputs().Should().BeEquivalentTo(stepInputs);
        }

        [Test]
        public void ExecuteShouldCallConsolePrinterWithStepName()
        {
            _subject.Execute(new List<StepInput>());

            A.CallTo(() => _consolePrinterDouble.Write("----==== PAYMENT PROCESS ====----")).MustHaveHappened();
        }

        [Test]
        public void ShouldReturnStepOutputWithTrueResult()
        {
            var stepOutput = _subject.Execute(new List<StepInput>());
            stepOutput.Result.Should().BeTrue();
        }

        [Test]
        public void ShouldReturnStepOutputWithCertainMessage()
        {
            const string message = "Payment step finished with success";

            var stepOutput = _subject.Execute(new List<StepInput>());

            stepOutput.Message.Should().Be(message);
        }
    }
}
