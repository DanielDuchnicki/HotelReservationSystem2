using System.Collections.Generic;

namespace HotelReservation.ReservationSteps
{
    internal class StepsExecutor
    {
        internal virtual void ExecuteSteps(List<IReservationStep> reservationSteps, List<StepInput> stepsData)
        {
            foreach (var reservationStep in reservationSteps)
            {
                reservationStep.Execute(stepsData);
            }
        }

    }

}