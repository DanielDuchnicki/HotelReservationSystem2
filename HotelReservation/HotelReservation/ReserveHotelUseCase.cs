using HotelReservation.ReservationSteps;
using System.Collections.ObjectModel;
using HotelReservation.Hotels;
using System.Collections.Generic;
using System.Linq;

namespace HotelReservation
{
    public class ReserveHotelUsecase
    {
        private HotelSystem _hotelSystem;
        private SystemInit _systemInit;
        private StepFactory _stepFactory;
        private StepsExecutor _stepExecutor;

        internal ReserveHotelUsecase(HotelSystem hotelSystem, StepFactory stepFactory, StepsExecutor stepExecutor)
        {
            _hotelSystem = hotelSystem;
            _stepFactory = stepFactory;
            _stepExecutor = stepExecutor;
            _systemInit = new SystemInit();
            _systemInit.AddHotels(_hotelSystem);
        }

        public ReserveHotelUsecase()
        {
            _hotelSystem = new HotelSystem();
            _stepFactory = new StepFactory();
            _stepExecutor = new StepsExecutor();
            _systemInit = new SystemInit();
            _systemInit.AddHotels(_hotelSystem);
        }
        public ReadOnlyCollection<Hotel> GetHotels()
        {
            return _hotelSystem.GetHotels();
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

        internal ReadOnlyCollection<StepInput> GetRequiredStepsInputs(List<IReservationStep> reservationSteps)
        {
            return new ReadOnlyCollection<StepInput>(reservationSteps.SelectMany(step => step.GetRequiredStepInputs())
                .GroupBy(step => step.Type).Select(grouping => grouping.First()).ToList());
        }

        public ReadOnlyCollection<StepInput> GetRequiredStepInputsForHotelId(int hotelId)
        {
            var reservationStepTypes = GetHotelReservationSteps(hotelId);
            var reservationSteps = CreateStepsInstances(reservationStepTypes);
            return GetRequiredStepsInputs(reservationSteps);
        }

        internal void ExecuteSteps(List<IReservationStep> reservationSteps, List<StepInput> stepsInputs)
        {
            _stepExecutor.ExecuteSteps(reservationSteps, stepsInputs);
        }

        public void ReserveHotel(int hotelId, List<StepInput> stepsInputs)
        {
            var reservationStepTypes = GetHotelReservationSteps(hotelId);
            var reservationSteps = CreateStepsInstances(reservationStepTypes);
            ExecuteSteps(reservationSteps, stepsInputs);
        }
    }
}
