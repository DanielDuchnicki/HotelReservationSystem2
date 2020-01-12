using HotelReservation.ReservationSteps;
using System.Collections.Generic;

namespace HotelReservation
{
    internal class StepsInstancesCreator
    {
        private StepFactory _stepFactory;

        public StepsInstancesCreator(StepFactory stepFactory)
        {
            _stepFactory = stepFactory;
        }
        public List<IReservationStep> Execute(List<ReservationStepType> reservationStepTypes)
        {
            var reservationSteps = new List<IReservationStep>();
            foreach (var reservationStepType in reservationStepTypes)
            {
                reservationSteps.Add(_stepFactory.CreateInstance(reservationStepType));
            }
            return reservationSteps;
        }
    }
}
