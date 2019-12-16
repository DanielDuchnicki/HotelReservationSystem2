using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelReservation.ReservationSteps.Reservation
{
    internal class ReservationStartProcess : IReservationStep
    {
        private ConsolePrinter _consolePrinter;
        private List<InputType> _requiredInputTypes = new List<InputType> { InputType.Name, InputType.EmailAddress };

        public ReservationStartProcess(ConsolePrinter consolePrinter)
        {
            _consolePrinter = consolePrinter;
        }

        public List<StepInput> GetRequiredStepInputs() => _requiredInputTypes.Select(type => new StepInput(type)).ToList();

        public virtual void Execute(List<StepInput> stepInputs)
        {
            string nameInput;
            try
            {
                nameInput = stepInputs.Find(stepInputData => stepInputData.Type == InputType.Name).Value;
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
