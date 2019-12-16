using System;
using System.Collections.Generic;

namespace HotelReservation.ReservationSteps.Reservation
{
    internal class ReservationStartProcess : IReservationStep
    {
        private ConsolePrinter _consolePrinter;
        private StepInput name = new StepInput(InputType.Name);
        private StepInput email = new StepInput(InputType.EmailAddress);
        private List<StepInput> stepInputs;

        public ReservationStartProcess(ConsolePrinter consolePrinter)
        {
            _consolePrinter = consolePrinter;
            stepInputs = new List<StepInput>{ name, email };
        }

        public List<StepInput> GetStepInputs()
        {
            return stepInputs;
        }

        public virtual void Execute(List<StepInput> stepInputs)
        {
            string nameInput;
            try
            {
                nameInput = stepInputs.Find(stepInputData => stepInputData.Identifier == name.Identifier).Value;
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("StepInput hasn't been correctly set!");
                //tu logowanie stacktrace
            }
      
            _consolePrinter.Write("----==== RESERVATION PROCESS ====----");
            _consolePrinter.Write(nameInput);
        }
    }
}
