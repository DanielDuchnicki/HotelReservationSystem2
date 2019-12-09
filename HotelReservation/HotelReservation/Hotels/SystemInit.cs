using System.Collections.Generic;
using HotelReservation.ReservationSteps;

namespace HotelReservation.Hotels
{
    internal class SystemInit
    {
        internal void AddHotels(HotelSystem hotelSystem)
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
            var thirdHotelReservationSteps = new List<ReservationStepType>()
            {
                ReservationStepType.PaymentProcess,
                ReservationStepType.SendingMailProcess
            };
            hotelSystem.AddNewHotel(firstHotelReservationSteps);
            hotelSystem.AddNewHotel(secondHotelReservationSteps);
            hotelSystem.AddNewHotel(thirdHotelReservationSteps);
        }
    }
}
