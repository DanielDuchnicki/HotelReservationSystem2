using System;
using System.Collections.Generic;

namespace HotelReservation.ReservationSteps
{
    public class StepsExecutor
    {
        public void ExecuteSteps(List<ReservationStepType> reservationSteps)
        {
            StepFactory reservationStepFactory = new StepFactory();
            foreach (var reservationStep in reservationSteps)
            {
                try
                {
                    reservationStepFactory.CreateInstance(reservationStep).Execute();
                }
                catch (Exception ex)
                {
                    throw new Exception("Something went wrong. Probably, you cannot access one of reservation steps. Please try again.", ex);
                }
            }
        }
    }
}

