using System;
using System.Collections.Generic;

namespace HotelReservation.ReservationSteps
{
    public class StepsExecutor
    {
        public void ExecuteSteps(List<ReservationStepType> reservationSteps, StepFactory reservationStepFactory)
        {
            foreach (var reservationStep in reservationSteps)
            {
                reservationStepFactory.CreateInstance(reservationStep).Execute();
            }
        }
    }
}

