using HotelReservation.Hotels;
using HotelReservation.ReservationSteps;
using System;
using System.Collections.Generic;

namespace HotelReservation
{
    public class UseCaseFactory
    {
        private readonly Dictionary<UseCaseType, Func<UseCase>> _reservationStepsInstances;
        private HotelSystem _hotelSystem;
        private StepFactory _stepFactory;
        private StepsExecutor _stepExecutor;
        private SystemInit _systemInit;

        public UseCaseFactory()
        {
            _hotelSystem = new HotelSystem();
            _stepFactory = new StepFactory();
            _stepExecutor = new StepsExecutor();
            _systemInit = new SystemInit();
            _systemInit.AddHotels(_hotelSystem);

            _reservationStepsInstances = new Dictionary<UseCaseType, Func<UseCase>>
                {
                    {UseCaseType.GetHotels, () => new GetHotelsUseCase(_hotelSystem)},
                    {UseCaseType.GetHotelRequiredStepInputs, () => new GetHotelRequiredStepInputsUseCase(_hotelSystem, _stepFactory)},
                    {UseCaseType.ReserveHotel, () => new ReserveHotelUsecase(_hotelSystem, _stepFactory, _stepExecutor)}
                };
        }

        public virtual UseCase CreateInstance(UseCaseType reservationStep)
        {
            Func<UseCase> instanceBuilder;
            if (!_reservationStepsInstances.TryGetValue(reservationStep, out instanceBuilder))
            {
                throw new NotImplementedException("There is no implementation of UseCase class for given UseCase Type");
            }
            return instanceBuilder();
        }
    }
}
