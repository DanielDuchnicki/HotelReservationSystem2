namespace HotelReservation.ReservationSteps
{
    class StepOutput
    {
        public bool Result { get; private set; }
        public string Message { get; private set; } = null;

        internal StepOutput(bool result, string message)
        {
            Result = result;
            Message = message;
        }
    }
}
