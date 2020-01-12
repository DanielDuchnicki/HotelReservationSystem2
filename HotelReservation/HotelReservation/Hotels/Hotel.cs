using System.Collections.Generic;
using HotelReservation.ReservationSteps;

namespace HotelReservation.Hotels
{
    public class Hotel
    {
        public int? HotelId { get; }
        internal List<ReservationStepType> ReservationSteps { get; }

        internal Hotel(int? hotelId, List<ReservationStepType> reservationSteps)
        {
            HotelId = hotelId;
            ReservationSteps = reservationSteps;
        }
    }
}
