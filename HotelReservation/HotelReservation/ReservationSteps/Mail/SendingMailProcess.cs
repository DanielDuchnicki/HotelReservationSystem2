using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelReservation.ReservationSteps.Mail
{
    internal class SendingMailProcess : IReservationStep
    {
        private ConsolePrinter _consolePrinter;
        private List<InputType> _requiredInputTypes = new List<InputType> { InputType.Name, InputType.EmailAddress };

        public SendingMailProcess(ConsolePrinter consolePrinter)
        {
            _consolePrinter = consolePrinter;
        }

        public List<StepInput> GetRequiredStepInputs() => _requiredInputTypes.Select(type => new StepInput(type)).ToList();

        public virtual void Execute(List<StepInput> stepInputs)
        {
            string nameInput;
            string mailInput;
            try
            {
                nameInput = stepInputs.Find(stepInputData => stepInputData.Type == InputType.Name).Value;
                mailInput = stepInputs.Find(stepInputData => stepInputData.Type == InputType.EmailAddress).Value;
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("StepInput hasn't been correctly set!");
                //tu logowanie stacktrace
            }
            _consolePrinter.Write("----==== SENDING MAIL PROCESS ====----");
            _consolePrinter.Write(nameInput);
            _consolePrinter.Write(mailInput);
        }
    }
}
