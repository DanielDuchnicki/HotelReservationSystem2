using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelReservation.ReservationSteps;
using System.Collections.ObjectModel;

namespace HotelReservation
{
    public class ReservationResult
    {
        public bool IsSuccessful { get; }
        public ReadOnlyCollection<InputType> IncorrectInputTypes { get; }

        public ReservationResult(bool isSuccessful, ReadOnlyCollection<InputType> incorrectInputTypes)
        {
            IsSuccessful = isSuccessful;
            IncorrectInputTypes = incorrectInputTypes;
        }
    }
}
