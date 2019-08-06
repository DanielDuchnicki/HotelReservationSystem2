using System;
using System.Collections.Generic;

namespace HotelReservation.Hotel.HotelData
{
    public abstract class HotelData
    {
        public abstract string HotelName { get; }
        public abstract double Price { get; }
        public abstract List<IConvertible> ReservationStepsData { get; }
    }
}
