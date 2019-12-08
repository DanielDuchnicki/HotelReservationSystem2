using HotelReservation.ReservationSteps;
using System.Collections.ObjectModel;
using HotelReservation.Hotels;

namespace HotelReservation
{
    public class ReserveHotelUsecase
    {
        private HotelSystem _hotelSystem;
        private SystemInit _systemInit;
        public ReserveHotelUsecase(HotelSystem hotelSystem)
        {
            _hotelSystem = hotelSystem;
            _systemInit = new SystemInit();
            _systemInit.AddHotels(_hotelSystem);
        }
        public ReadOnlyCollection<Hotel> GetHotels()
        {
            return _hotelSystem.GetHotels();
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
