namespace HotelReservation.ReservationSteps
{
    public class StepOutput
    {
        public bool IsSuccessful { get; }
        public string Message { get; }

        internal StepOutput(bool isSuccessful, string message)
        {
            IsSuccessful = isSuccessful;
            Message = message;
        }
    }
}
