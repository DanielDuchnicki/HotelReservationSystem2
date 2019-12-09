using System.Collections.Generic;
using HotelReservation.ReservationSteps;

namespace HotelReservation.Hotels
{
    public class Hotel
    {
        public int? HotelId { get; private set; }
        internal List<ReservationStepType> ReservationSteps { get; private set; }

        internal Hotel(int? hotelId, List<ReservationStepType> reservationSteps)
        {
            HotelId = hotelId;
            ReservationSteps = reservationSteps;
        }
    }
}
