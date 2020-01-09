using HotelReservation.ReservationSteps;
using HotelReservation.Hotels;
using System.Collections.Generic;

namespace HotelReservation
{
    public class ReserveHotelUsecase
    {
        private HotelSystem _hotelSystem;
        private StepFactory _stepFactory;
        private StepsExecutor _stepExecutor;

        internal ReserveHotelUsecase(HotelSystem hotelSystem, StepFactory stepFactory, StepsExecutor stepExecutor)
        {
            _hotelSystem = hotelSystem;
            _stepFactory = stepFactory;
            _stepExecutor = stepExecutor;
        }

        public void ReserveHotel(int hotelId, List<StepInput> stepsInputs)
        {
            var reservationStepTypes = GetHotelReservationSteps(hotelId);
            var reservationSteps = CreateStepsInstances(reservationStepTypes);
            ExecuteSteps(reservationSteps, stepsInputs);
        }

        private List<ReservationStepType> GetHotelReservationSteps(int hotelId)
        {
            return _hotelSystem.GetHotelReservationSteps(hotelId);
        }

        private List<IReservationStep> CreateStepsInstances(List<ReservationStepType> reservationStepTypes)
        {
            var reservationSteps = new List<IReservationStep>();
            foreach (var reservationStepType in reservationStepTypes)
            {
                reservationSteps.Add(_stepFactory.CreateInstance(reservationStepType));
            }
            return reservationSteps;
        }

        private void ExecuteSteps(List<IReservationStep> reservationSteps, List<StepInput> stepsInputs)
        {
            _stepExecutor.ExecuteSteps(reservationSteps, stepsInputs);
        }
    }
}
