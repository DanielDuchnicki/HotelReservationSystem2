using System;

namespace HotelReservation.ReservationSteps
{
    public class StepInput
    {
        public Type InputType { get; private set; }
        public string Identifier { get; private set; }
        public string QuestionText { get; private set; }
        public dynamic Value { get; private set; }

        public StepInput(Type type, string identifier, string questionText)
        {
            InputType = type;
            Identifier = identifier;
            QuestionText = questionText;
        }

        public void setValue(dynamic value)
        {
            Value = value;
        }
    }
}
