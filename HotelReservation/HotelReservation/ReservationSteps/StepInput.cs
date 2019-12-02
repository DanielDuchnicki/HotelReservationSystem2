using System;

namespace HotelReservation.ReservationSteps
{
    public class StepInput
    {
        public Type InputType { get; private set; }
        public QuestionIdentifier Identifier { get; private set; }
        public string Value { get; private set; }

        public StepInput(Type type, QuestionIdentifier identifier)
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
