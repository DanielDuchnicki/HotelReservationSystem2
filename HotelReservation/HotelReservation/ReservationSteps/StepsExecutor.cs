using System.Collections.Generic;
using System.Linq;

namespace HotelReservation.ReservationSteps
{
    internal class StepsExecutor
    {
        public virtual List<StepOutput> ExecuteSteps(List<IReservationStep> reservationSteps, List<StepInput> stepsData)
        {
            return reservationSteps.Select(reservationStep => reservationStep.Execute(stepsData)).ToList();
        }
    }
}