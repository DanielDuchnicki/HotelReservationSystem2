using System;

namespace HotelReservation.ReservationSteps
{
    public class StepInput
    {
        public Type InputType { get; private set; }
        public string Identifier { get; private set; }
        public string Value { get; private set; }

        public StepInput(Type type, string identifier)
        {
            InputType = type;
            Identifier = identifier;
            Value = null;
        }

        public void SetValue(string value)
        {
            Value = value;
        }
    }
}
