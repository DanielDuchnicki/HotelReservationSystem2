using System.Collections.Generic;

namespace HotelReservation.ReservationSteps.Reservation
{
    public class ReservationStartProcess : IReservationStep
    {
        private ConsolePrinter _consolePrinter;
        private StepInput name = new StepInput(typeof(string), "name");
        private List<StepInput> stepInputs;

        public ReservationStartProcess(ConsolePrinter consolePrinter)
        {
            _consolePrinter = consolePrinter;
            stepInputs = new List<StepInput>{name};
        }

        public List<StepInput> GetStepInputs()
        {
            return stepInputs;
        }

        public void Execute()
        {
            _consolePrinter.Write("----==== RESERVATION PROCESS ====----");
            _consolePrinter.Write(name.Value);
        }
    }
}
