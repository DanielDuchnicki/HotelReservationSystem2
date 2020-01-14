namespace HotelReservation.ReservationSteps
{
    public class StepOutput
    {
        public bool Result { get; }
        public string Message { get; }

        internal StepOutput(bool result, string message)
        {
            Result = result;
            Message = message;
        }
    }
}
