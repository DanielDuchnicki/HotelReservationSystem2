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

        public List<StepInput> SetStepInputsValues(List<StepInput> stepInputs, List<StepInput> stepsData)
        {
            foreach (var stepInput in stepInputs)
            {
                stepInput.SetValue(stepsData.Find(stepInputData => stepInputData.Identifier == stepInput.Identifier).Value);
            }
            return stepInputs;
        }

        public void ExecuteSteps(List<ReservationStepType> reservationSteps, List<StepInput> stepsData)
        {
            IReservationStep reservationStepInstance;
            foreach (var reservationStep in reservationSteps)
            {
                reservationStepInstance = _stepFactory.CreateInstance(reservationStep);
                SetStepInputsValues(reservationStepInstance.GetStepInputs(), stepsData);
                reservationStepInstance.Execute();
            }
        }

    }

}