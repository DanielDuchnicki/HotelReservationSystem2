using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HotelReservation.ReservationSteps
{
    internal class StepOutput
    {
        public List<InputType> IncorrectInputsTypes { get; }

        internal StepOutput(List<InputType> incorrectInputsTypes)
        {
            IncorrectInputsTypes = incorrectInputsTypes;
        }
    }
}
