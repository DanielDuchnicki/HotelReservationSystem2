using System;
using System.Collections.Generic;

namespace HotelReservation.Hotel
{
    public class Hotel
    {
        public int HotelId { get; }
        public string HotelName { get; }
        public double Price { get; }
        public List<IConvertible> ReservationSteps { get; }

        public Hotel(int hotelId, string hotelName, double price,
            List<IConvertible> reservationSteps)
        {
            HotelId = hotelId;
            HotelName = hotelName;
            Price = price;
            ReservationSteps = reservationSteps;
        }
    }
}
