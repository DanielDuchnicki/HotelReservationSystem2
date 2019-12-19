using HotelReservation.Hotels;
using System.Collections.ObjectModel;

namespace HotelReservation
{
    public class GetHotelsUseCase : UseCase
    {
        private HotelSystem _hotelSystem;

        internal GetHotelsUseCase(HotelSystem hotelSystem)
        {
            _hotelSystem = hotelSystem;
        }

        public override ReadOnlyCollection<Hotel> GetHotels()
        {
            return _hotelSystem.GetHotels();
        }
    }
}
