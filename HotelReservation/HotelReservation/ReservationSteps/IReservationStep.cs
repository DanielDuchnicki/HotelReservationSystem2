namespace HotelReservation.ReservationSteps
{
    public interface IReservationStep
    {
        void Execute(IStepData stepData);
    }
}
