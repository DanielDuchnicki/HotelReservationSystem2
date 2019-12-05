﻿using System;

namespace HotelReservation.ReservationSteps
{
    public class StepInput
    {
        public InputType Identifier { get; private set; }
        public string Value { get; private set; }

        public StepInput(InputType identifier)
        {
            Identifier = identifier;
            Value = null;
        }

        public void SetValue(string value)
        {
            Value = value;
        }
    }
}
