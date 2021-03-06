﻿using FluentAssertions;
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

        [SetUp]
        public void BeforeTest()
        {
            _subject = new PaymentProcess();
        }

        [Test]
        public void ShouldProvidePaymentProcessInputs()
        {
            var stepInputs = new List<StepInput>();

            _subject.GetRequiredStepInputs().Should().BeEquivalentTo(stepInputs);
        }

        [Test]
        public void ShouldReturnStepOutputWithEmptyIncorrectInputTypes()
        {
            var stepOutput = _subject.Execute(new List<StepInput>());

            stepOutput.IncorrectInputsTypes.Should().BeEmpty();
        }
    }
}
