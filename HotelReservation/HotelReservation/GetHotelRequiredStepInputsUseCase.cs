using HotelReservation.Hotels;
using HotelReservation.ReservationSteps;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace HotelReservation
{
    public class GetHotelRequiredStepInputsUseCase : UseCase
    {
        private HotelSystem _hotelSystem;
        private StepFactory _stepFactory;

        internal GetHotelRequiredStepInputsUseCase(HotelSystem hotelSystem, StepFactory stepFactory)
        {
            _hotelSystem = hotelSystem;
            _stepFactory = stepFactory;
        }

        public override ReadOnlyCollection<StepInput> GetRequiredStepInputsForHotelId(int hotelId)
        {
            var reservationStepTypes = GetHotelReservationSteps(hotelId);
            var reservationSteps = CreateStepsInstances(reservationStepTypes);
            return GetRequiredStepsInputs(reservationSteps);
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
    }
}
