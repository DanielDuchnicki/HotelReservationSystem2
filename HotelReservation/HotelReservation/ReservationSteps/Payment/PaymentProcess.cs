using System.Collections.Generic;

namespace HotelReservation.ReservationSteps.Payment
{
    public class PaymentProcess : IReservationStep
    {
        public void Execute(ConsolePrinter consolePrinter, List<StepInput> stepData)
        {
            new ConsolePrinter().Execute("----==== PAYMENT PROCESS ====----");
        }
    }
}
