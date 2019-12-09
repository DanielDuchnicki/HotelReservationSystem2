using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using HotelReservation.ReservationSteps;

namespace HotelReservation.Hotels
{
    internal class HotelSystem
    {
        private readonly List<Hotel> _hotels = new List<Hotel>();
        internal int? LastHotelId { get; private set; } = null;

        internal void AddNewHotel(List<ReservationStepType> hotelReservationSteps)
        {
            LastHotelId = (LastHotelId == null) ? 1 : ++LastHotelId;
            var newHotel = new Hotel(LastHotelId, hotelReservationSteps);
            _hotels.Add(newHotel);
        }

        internal virtual ReadOnlyCollection<Hotel> GetHotels()
        {
            return new ReadOnlyCollection<Hotel>(_hotels);
        }

        internal virtual List<ReservationStepType> GetHotelReservationSteps(int hotelId)
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
