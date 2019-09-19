using System.Collections.Generic;
using HotelReservation.ReservationSteps;

namespace HotelReservation.Hotels
{
    public class HotelSystem
    {
        private readonly List<Hotel> _hotels = new List<Hotel>();
        public int LastHotelId { get; private set; } = 1000;

        public void AddNewHotel(List<ReservationStepType> hotelReservationSteps)
        {
            var hotelId = LastHotelId;
            var newHotel = new Hotel(hotelId, hotelReservationSteps);
            _hotels.Add(newHotel);
            LastHotelId++;
        }

        public List<Hotel> GetHotels()
        {
            return _hotels;
        }

        public List<ReservationStepType> GetHotelReservationSteps(int hotelId)
        {
            return _hotels.Find(hotel => hotel.HotelId == hotelId).ReservationSteps;
        }
    }
}
