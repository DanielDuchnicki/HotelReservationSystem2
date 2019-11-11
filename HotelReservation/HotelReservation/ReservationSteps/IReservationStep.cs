using System.Collections.Generic;

namespace HotelReservation.ReservationSteps
{
    public interface IReservationStep
    {
        void Execute(ConsolePrinter consolePrinter, List<StepInput> stepData);
    }
}
