namespace HotelReservation.ReservationSteps
{
    public class StepInput
    {
        public InputType Type { get; private set; }
        public string Value { get; set; } = null;

        internal StepInput(InputType type)
        {
            Type = type;
        }
    }
}
