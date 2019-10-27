using System.Collections.Generic;
using HotelReservation.ReservationSteps;

namespace HotelReservation.Hotels
{
    public class SystemInit
    {
        public void AddHotels(HotelSystem hotelSystem)
        {
            var firstHotelReservationSteps = new List<ReservationStepType>()
            {
                ReservationStepType.ReservationProcess,
                ReservationStepType.PaymentProcess,
                ReservationStepType.SendingMailProcess
            };
            var secondHotelReservationSteps = new List<ReservationStepType>()
            {
                ReservationStepType.ReservationProcess,
                ReservationStepType.SendingMailProcess
            };
            hotelSystem.AddNewHotel(firstHotelReservationSteps);
            hotelSystem.AddNewHotel(secondHotelReservationSteps);
        }
    }
}
