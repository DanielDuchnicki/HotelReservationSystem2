using System.Collections.Generic;
using HotelReservation.ReservationSteps;

namespace HotelReservation.Hotels
{
    public class Hotel
    {
        public int HotelId { get; }
        public List<ReservationStepType> ReservationSteps { get; }

        public Hotel(int hotelId, List<ReservationStepType> reservationSteps)
        {
            HotelId = hotelId;
            ReservationSteps = reservationSteps;
        }
    }
}
