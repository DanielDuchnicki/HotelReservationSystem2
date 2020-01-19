using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HotelReservation.ReservationSteps
{
    internal class StepOutput
    {
        public bool IsSuccessful { get; }
        public List<InputType> IncorrectInputsTypes { get; }

        internal StepOutput(bool isSuccessful, List<InputType> incorrectInputsTypes)
        {
            IsSuccessful = isSuccessful;
            IncorrectInputsTypes = incorrectInputsTypes;
        }
    }
}
