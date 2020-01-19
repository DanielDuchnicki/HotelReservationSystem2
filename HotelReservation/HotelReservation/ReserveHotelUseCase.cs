using HotelReservation.ReservationSteps;
using HotelReservation.Hotels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace HotelReservation
{
    public class ReserveHotelUsecase
    {
        private readonly HotelSystem _hotelSystem;
        private readonly StepFactory _stepFactory;
        private readonly StepsExecutor _stepExecutor;

        internal ReserveHotelUsecase(HotelSystem hotelSystem, StepFactory stepFactory, StepsExecutor stepExecutor)
        {
            _hotelSystem = hotelSystem;
            _stepFactory = stepFactory;
            _stepExecutor = stepExecutor;
        }

        public ReservationResult ReserveHotel(int hotelId, List<StepInput> stepsInputs)
        {
            var reservationStepTypes = GetHotelReservationSteps(hotelId);
            var reservationSteps = new StepsInstancesCreator(_stepFactory).Execute(reservationStepTypes);
            var stepOutputs = ExecuteSteps(reservationSteps, stepsInputs);

            var incorrectInputTypes = new List<InputType>();
            foreach (var stepOutput in stepOutputs)
            {
                if (!stepOutput.IsSuccessful)
                    incorrectInputTypes.AddRange(stepOutput.IncorrectInputsTypes.Except(incorrectInputTypes));
            }

            return incorrectInputTypes.Count().Equals(0) ?
                new ReservationResult(true, new ReadOnlyCollection<InputType>(incorrectInputTypes)) : 
                new ReservationResult(false, new ReadOnlyCollection<InputType>(incorrectInputTypes));
        }

        private List<ReservationStepType> GetHotelReservationSteps(int hotelId)
        {
            return _hotelSystem.GetHotelReservationSteps(hotelId);
        }

        private ReadOnlyCollection<StepOutput> ExecuteSteps(List<IReservationStep> reservationSteps, List<StepInput> stepsInputs)
        {
            return new ReadOnlyCollection<StepOutput>(_stepExecutor.ExecuteSteps(reservationSteps, stepsInputs));
        }
    }
}
