namespace HotelReservation.ReservationSteps
{
    public class StepInput
    {
        public InputType Type { get; }
        public string Value { get; set; } = null;

        internal StepInput(InputType type)
        {
            Type = type;
        }
    }
}
