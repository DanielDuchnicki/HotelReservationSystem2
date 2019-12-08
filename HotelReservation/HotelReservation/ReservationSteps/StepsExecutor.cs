using System.Collections.Generic;

namespace HotelReservation.ReservationSteps
{
    public class StepsExecutor
    {
        public virtual void ExecuteSteps(List<IReservationStep> reservationSteps, List<StepInput> stepsData)
        {
            foreach (var reservationStep in reservationSteps)
            {
                reservationStep.Execute(stepsData);
            }
        }

    }

}