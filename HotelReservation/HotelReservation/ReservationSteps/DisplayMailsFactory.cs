namespace HotelReservation.ReservationSteps
{
    class DisplayMailsFactory : ReservationStepsFactory
    {
        public override IReservationStep Create() => new DisplayMails();
    }
}
