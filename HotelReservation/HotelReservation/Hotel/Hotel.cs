using System.Collections.Generic;

namespace HotelReservation.Hotel
{
    public class Hotel
    {
        public int HotelId { get; }
        public List<ReservationSteps.ReservationSteps> ReservationSteps { get; }

        public Hotel(int hotelId, List<ReservationSteps.ReservationSteps> reservationSteps)
        {
            HotelId = hotelId;
            ReservationSteps = reservationSteps;
        }
    }
}
