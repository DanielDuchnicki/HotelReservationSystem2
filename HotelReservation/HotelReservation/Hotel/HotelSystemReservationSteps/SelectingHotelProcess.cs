using System;

namespace HotelReservation.Hotel.HotelSystemReservationSteps
{
    public class SelectingHotelProcess : IHotelSystemReservationStep
    {
        public int Execute(HotelSystem hotelSystem)
        {
            Console.WriteLine("Please check list of hotels and choose one for you!");
            Console.WriteLine("Please provide hotel ID: ");
            var selectedHotelId = Console.ReadLine();
            var hotelId = Convert.ToInt32(selectedHotelId);
            Console.WriteLine();
            return hotelId;
        }
    }
}
