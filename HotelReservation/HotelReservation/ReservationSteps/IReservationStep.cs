using System.Collections.Generic;

namespace HotelReservation.ReservationSteps
{
    internal interface IReservationStep
    {
        StepOutput Execute(List<StepInput> stepInputs);
        List<StepInput> GetRequiredStepInputs();
    }
}
