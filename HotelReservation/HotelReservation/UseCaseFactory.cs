using HotelReservation.Hotels;
using HotelReservation.ReservationSteps;

namespace HotelReservation
{
    public class UseCaseFactory
    {
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
        }

        public GetHotelsUseCase CreateGetHotelsUseCase()
        {
            return new GetHotelsUseCase(_hotelSystem);
        }

        public GetHotelRequiredStepInputsUseCase CreateGetHotelRequiredStepInputsUseCase()
        {
            return new GetHotelRequiredStepInputsUseCase(_hotelSystem, _stepFactory);
        }

        public ReserveHotelUsecase CreateReserveHotelUsecase()
        {
            return new ReserveHotelUsecase(_hotelSystem, _stepFactory, _stepExecutor);
        }
    }
}
