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

        public void ExecuteSteps(List<ReservationStepType> reservationSteps, List<IStepData> stepsData)
        {
            foreach (var reservationStep in reservationSteps)
                _stepFactory.CreateInstance(reservationStep).Execute(stepsData.Find(stepData => stepData.ReservationStep == reservationStep));
        }

    }

}