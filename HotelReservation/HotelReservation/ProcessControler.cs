using HotelReservation.ReservationSteps;
using System.Collections.ObjectModel;
using HotelReservation.Hotels;

namespace HotelReservation
{
    public class ProcessControler
    {
        public ReadOnlyCollection<Hotel> GetHotels()
        {
            return null;
        }

        public ReadOnlyCollection<ReservationStepType> GetHotelReservationSteps(int hotelId)
        {
            return null;
        }

        public ReadOnlyCollection<IReservationStep> CreateSteps(ReadOnlyCollection<ReservationStepType> stepsTypes)
        {
            return null;
        }

        public ReadOnlyCollection<StepInput> GetStepsInputs(ReadOnlyCollection<IReservationStep> reservationSteps)
        {
            return null;
        }

        public void ExecuteSteps(ReadOnlyCollection<StepInput> stepsInputs)
        {

        }

    }
}
