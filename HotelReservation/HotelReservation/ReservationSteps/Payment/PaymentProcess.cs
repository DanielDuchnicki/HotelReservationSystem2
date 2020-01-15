using System.Collections.Generic;
using System.Linq;

namespace HotelReservation.ReservationSteps.Payment
{
    internal class PaymentProcess : IReservationStep
    {
        private readonly List<InputType> _requiredInputTypes = new List<InputType>();

        public List<StepInput> GetRequiredStepInputs() => _requiredInputTypes.Select(type => new StepInput(type)).ToList();

        public virtual StepOutput Execute(List<StepInput> stepInputs)
        {
            //temporary solution
            return new StepOutput(true, "Payment step finished with success");
        }
    }
}
