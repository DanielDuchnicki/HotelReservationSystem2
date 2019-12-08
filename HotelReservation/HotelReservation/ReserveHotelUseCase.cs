using HotelReservation.ReservationSteps;
using System.Collections.ObjectModel;
using HotelReservation.Hotels;
using System.Collections.Generic;

namespace HotelReservation
{
    public class ReserveHotelUsecase
    {
        private HotelSystem _hotelSystem;
        private SystemInit _systemInit;
        private StepFactory _stepFactory;
        public ReserveHotelUsecase(HotelSystem hotelSystem, StepFactory stepFactory)
        {
            _hotelSystem = hotelSystem;
            _stepFactory = stepFactory;
            _systemInit = new SystemInit();
            _systemInit.AddHotels(_hotelSystem);
        }
        public ReadOnlyCollection<Hotel> GetHotels()
        {
            return _hotelSystem.GetHotels();
        }

        public List<ReservationStepType> GetHotelReservationSteps(int hotelId)
        {
            return _hotelSystem.GetHotelReservationSteps(hotelId);
        }

        public List<IReservationStep> CreateStepsInstances(List<ReservationStepType> reservationStepTypes)
        {
            List<IReservationStep> reservationSteps = new List<IReservationStep>();
            foreach (var reservationStepType in reservationStepTypes)
            {
                reservationSteps.Add(_stepFactory.CreateInstance(reservationStepType));
            }
            return reservationSteps;
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
