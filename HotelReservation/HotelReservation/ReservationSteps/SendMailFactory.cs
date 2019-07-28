namespace HotelReservation.ReservationSteps
{
    class SendMailFactory : ReservationStepsFactory
    {
        public override IReservationStep Create() => new SendMail();
    }
}
