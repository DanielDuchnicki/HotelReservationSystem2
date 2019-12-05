using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace HotelReservation.ReservationSteps.Reservation
{
    public class ReservationStartProcess : IReservationStep
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

        public void Execute(List<StepInput> stepInputs)
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
