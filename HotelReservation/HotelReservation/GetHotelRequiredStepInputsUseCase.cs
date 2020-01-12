using HotelReservation.Hotels;
using HotelReservation.ReservationSteps;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace HotelReservation
{
    public class GetHotelRequiredStepInputsUseCase
    {
        private HotelSystem _hotelSystem;
        private StepFactory _stepFactory;

        internal GetHotelRequiredStepInputsUseCase(HotelSystem hotelSystem, StepFactory stepFactory)
        {
            _hotelSystem = hotelSystem;
            _stepFactory = stepFactory;
        }

        public ReadOnlyCollection<StepInput> GetRequiredStepInputsForHotelId(int hotelId)
        {
            var reservationStepTypes = GetHotelReservationSteps(hotelId);
            var reservationSteps = new StepsInstancesCreator(_stepFactory).Execute(reservationStepTypes);
            return GetRequiredStepsInputs(reservationSteps);
        }

        private List<ReservationStepType> GetHotelReservationSteps(int hotelId)
        {
            return _hotelSystem.GetHotelReservationSteps(hotelId);
        }

        private ReadOnlyCollection<StepInput> GetRequiredStepsInputs(List<IReservationStep> reservationSteps)
        {
            return new ReadOnlyCollection<StepInput>(reservationSteps.SelectMany(step => step.GetRequiredStepInputs())
                .GroupBy(step => step.Type).Select(grouping => grouping.First()).ToList());
        }
    }
}
