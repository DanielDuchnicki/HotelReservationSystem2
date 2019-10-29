namespace HotelReservation.ReservationSteps.Mail
{
    public class SendingMailProcessData : IStepData
    {
        public string EmailAddress { get; private set; }
        public ReservationStepType ReservationStep { get; set; }

        public SendingMailProcessData(string emailAddress)
        {
            ReservationStep = ReservationStepType.SendingMailProcess;
            EmailAddress = emailAddress;
        }
    }
}
