namespace HotelReservation.Mail
{
    public class SendingMailProcessFactory : MailSystemReservationStepsFactory
    {
        public override IMailSystemReservationStep Create() => new SendingMailProcess();
    }
}
