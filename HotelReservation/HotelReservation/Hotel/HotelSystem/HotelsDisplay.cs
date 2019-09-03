using System;

namespace HotelReservation.Hotel.HotelSystem
{
    public class HotelsDisplay
    {
        public void DisplayHotels(HotelSystem hotelSystem)
        {
            if (hotelSystem.Hotels.Count == 0)
                Console.WriteLine("There are no hotels added to the reservation system.");
            else
            {
                Console.WriteLine("[Hotel ID, Name, Price (for each day), Is free?]");
                foreach (var hotel in hotelSystem.Hotels)
                {
                    Console.WriteLine("Hotel ID: " + hotel.HotelId);
                }
            }
            Console.WriteLine();
        }
    }
}
