using HotelReservation.ReservationSteps;
using HotelReservation.Hotels;
using System.Collections.Generic;

namespace HotelReservation
{
    public class ReserveHotelUsecase : UseCase
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

        public override void ReserveHotel(int hotelId, List<StepInput> stepsInputs)
        {
            var reservationStepTypes = GetHotelReservationSteps(hotelId);
            var reservationSteps = CreateStepsInstances(reservationStepTypes);
            ExecuteSteps(reservationSteps, stepsInputs);
        }

        internal List<ReservationStepType> GetHotelReservationSteps(int hotelId)
        {
            return _hotelSystem.GetHotelReservationSteps(hotelId);
        }

        internal List<IReservationStep> CreateStepsInstances(List<ReservationStepType> reservationStepTypes)
        {
            List<IReservationStep> reservationSteps = new List<IReservationStep>();
            foreach (var reservationStepType in reservationStepTypes)
            {
                reservationSteps.Add(_stepFactory.CreateInstance(reservationStepType));
            }
            return reservationSteps;
        }

        internal void ExecuteSteps(List<IReservationStep> reservationSteps, List<StepInput> stepsInputs)
        {
            _stepExecutor.ExecuteSteps(reservationSteps, stepsInputs);
        }
    }
}
