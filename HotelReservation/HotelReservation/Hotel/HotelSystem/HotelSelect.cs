using System;

namespace HotelReservation.Hotel.HotelSystem
{
    public class HotelSelect
    {
        public int SelectHotel(HotelSystem hotelSystem)
        {
            Console.WriteLine("Please check list of hotels and choose one for you!");
            Console.WriteLine("Please provide hotel ID: ");
            var selectedHotelId = Console.ReadLine();
            var parsedHotelId = 0;
            Console.WriteLine();
            return !int.TryParse(selectedHotelId, out parsedHotelId) ? 0 : parsedHotelId;
        }
    }
}
