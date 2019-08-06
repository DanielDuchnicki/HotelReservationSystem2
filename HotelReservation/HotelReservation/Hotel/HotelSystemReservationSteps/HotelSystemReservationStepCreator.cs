using System;
using System.Collections.Generic;

namespace HotelReservation.Hotel.HotelSystemReservationSteps
{
    public class HotelSystemReservationStepCreator
    {
        private readonly Dictionary<IConvertible, HotelSystemReservationStepsFactory> _reservationStepsFactories;

        public HotelSystemReservationStepCreator()
        {
            _reservationStepsFactories = new Dictionary<IConvertible, HotelSystemReservationStepsFactory>
            {
                {HotelReservationSteps.HotelsDisplayProcess, new HotelsDisplayProcessFactory() },
                {HotelReservationSteps.ReservationProcess, new HotelSystemReservationProcessFactory() },
                {HotelReservationSteps.SelectingHotelProcess, new SelectingHotelProcessFactory() }
            };
        }

        public IHotelSystemReservationStep ExecuteReservationStepCreation(IConvertible reservationStep) =>
            _reservationStepsFactories[reservationStep].Create();
    }
}
