using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelReservation.ReservationSteps.Mail
{
    internal class SendingMailProcess : IReservationStep
    {
        private readonly List<InputType> _requiredInputTypes = new List<InputType> { InputType.Name, InputType.EmailAddress };

        public List<StepInput> GetRequiredStepInputs() => _requiredInputTypes.Select(type => new StepInput(type)).ToList();

        public virtual StepOutput Execute(List<StepInput> stepInputs)
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

            var incorrectStepInputTypes = new List<InputType>();

            if (string.IsNullOrEmpty(nameInput))
                incorrectStepInputTypes.Add(InputType.Name);
            if (string.IsNullOrEmpty(mailInput))
                incorrectStepInputTypes.Add(InputType.EmailAddress);

            return new StepOutput(incorrectStepInputTypes);
        }
    }
}
