using System.Collections.Generic;
using System.Linq;

namespace HotelReservation.ReservationSteps
{
    public class StepsExecutor
    {
        private readonly StepFactory _stepFactory;
        public StepsExecutor(StepFactory stepFactory)
        {
            _stepFactory = stepFactory;
        }

        public void ExecuteSteps(List<ReservationStepType> reservationSteps)
        {
            foreach (var reservationStep in reservationSteps)
                _stepFactory.CreateInstance(reservationStep).Execute();
        }

    }

}