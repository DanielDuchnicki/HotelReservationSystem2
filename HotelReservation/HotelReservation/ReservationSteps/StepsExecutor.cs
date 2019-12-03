using System.Collections.Generic;

namespace HotelReservation.ReservationSteps
{
    public class StepsExecutor
    {
        private readonly StepFactory _stepFactory;
        public StepsExecutor(StepFactory stepFactory)
        {
            _stepFactory = stepFactory;
        }

        public void ExecuteSteps(List<ReservationStepType> reservationSteps, List<StepInput> stepsData)
        {
            IReservationStep reservationStepInstance;
            foreach (var reservationStep in reservationSteps)
            {
                reservationStepInstance = _stepFactory.CreateInstance(reservationStep);
                reservationStepInstance.Execute(stepsData);
            }
        }

    }

}