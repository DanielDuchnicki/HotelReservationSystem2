using System;

namespace HotelReservation.Hotel.HotelSystemReservationSteps
{
    public class HotelsDisplayProcess : IHotelSystemReservationStep
    {
        public int Execute(HotelSystem hotelSystem)
        {
            if (hotelSystem.Hotels.Count == 0)
                Console.WriteLine("There are no hotels added to the reservation system.");
            else
            {
                Console.WriteLine("[Hotel ID, Name, Price (for each day), Is free?]");
                foreach (var hotel in hotelSystem.Hotels)
                {
                    Console.WriteLine(hotel.HotelId + ",  " +
                                      hotel.HotelName + ",  " +
                                      hotel.Price);
                }
            }
            Console.WriteLine();
            return 0;
        }
    }
}
