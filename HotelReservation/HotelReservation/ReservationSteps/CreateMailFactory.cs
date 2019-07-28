namespace HotelReservation.ReservationSteps
{
    class CreateMailFactory : ReservationStepsFactory
    {
        public override IReservationStep Create() => new CreateMail();
    }
}
