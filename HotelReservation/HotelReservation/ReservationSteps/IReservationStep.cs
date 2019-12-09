using System.Collections.Generic;

namespace HotelReservation.ReservationSteps
{
    internal interface IReservationStep
    {
        void Execute(List<StepInput> stepInputs);
        List<StepInput> GetStepInputs();
    }
}
