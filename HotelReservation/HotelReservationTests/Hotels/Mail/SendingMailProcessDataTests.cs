using HotelReservation.ReservationSteps;
using HotelReservation.ReservationSteps.Mail;
using FluentAssertions;
using NUnit.Framework;

namespace HotelReservationTests.Hotels.Mail
{
    [TestFixture]
    public class SendingMailProcessDataTests
    {
        [Test]
        public void ShouldCreateSendingMailProcessDataWithCorrectReservationType()
        {
            var sendingMailProcessData = new SendingMailProcessData("");
            sendingMailProcessData.ReservationStep.Should().Be(ReservationStepType.SendingMailProcess);
        }

        [Test]
        public void ShouldCreateSendingMailProcessDataWithProvidedEmailAddress()
        {
            var sendingMailProcessData = new SendingMailProcessData("mail@hotelReservation.com");
            sendingMailProcessData.EmailAddress.Should().Be("mail@hotelReservation.com");
        }
    }
}
