using System.Collections.Generic;

namespace HotelReservation.ReservationSteps.Reservation
{
    public class ReservationStartProcess : IReservationStep
    {
        string name;
        public void Execute(ConsolePrinter consolePrinter, List<StepInput> stepData)
        {
            name = stepData.Find(stepInput => stepInput.Identifier == "name").Value;

            consolePrinter.Execute("----==== RESERVATION PROCESS ====----");
            consolePrinter.Execute(name);
        }
    }
}
