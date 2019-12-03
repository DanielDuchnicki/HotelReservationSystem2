﻿using System.Collections.Generic;

namespace HotelReservation.ReservationSteps
{
    public interface IReservationStep
    {
        void Execute(List<StepInput> stepInputs);
        List<StepInput> GetStepInputs();
    }
}
