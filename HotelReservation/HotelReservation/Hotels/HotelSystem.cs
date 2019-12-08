using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using HotelReservation.ReservationSteps;

namespace HotelReservation.Hotels
{
    public class HotelSystem
    {
        private readonly List<Hotel> _hotels = new List<Hotel>();
        public int? LastHotelId { get; private set; } = null;

        public void AddNewHotel(List<ReservationStepType> hotelReservationSteps)
        {
            LastHotelId = (LastHotelId == null) ? 1 : ++LastHotelId;
            var newHotel = new Hotel(LastHotelId, hotelReservationSteps);
            _hotels.Add(newHotel);
        }

        public virtual ReadOnlyCollection<Hotel> GetHotels()
        {
            return new ReadOnlyCollection<Hotel>(_hotels);
        }

        public List<ReservationStepType> GetHotelReservationSteps(int hotelId)
        {
            try
            {
                return _hotels.Find(hotel => hotel.HotelId == hotelId).ReservationSteps;
            }
            catch(NullReferenceException ex)
            {
                throw new ArgumentException("You provided incorrect hotel ID. Please try again.", ex);
            }
        }
    }
}
