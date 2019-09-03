using System;
using HotelReservation.Hotel.HotelSystem;
using HotelReservation.ReservationSteps;

namespace HotelReservation
{
    public class SystemMain
    {
        public static void DisplayMenu()
        {
            Console.WriteLine();
            Console.WriteLine("----==== RESERVATION SYSTEM ====----");
            Console.WriteLine("1 - Start new reservation");
            Console.WriteLine();
            Console.WriteLine("0 - EXIT");
            Console.WriteLine();
            Console.WriteLine("Choose, what you want to do:");
        }

        public static int Menu(HotelSystem hotelSystem, StepsExecutor stepsExecutor)
        {
            DisplayMenu();
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "0":
                    Console.WriteLine("Exit selected");
                    break;
                case "1":
                    Console.Clear();
                    new HotelsDisplay().DisplayHotels(hotelSystem);
                    var hotelId = new HotelSelect().SelectHotel(hotelSystem);
                    Console.Clear();
                    if (hotelId >= 1000)
                        stepsExecutor.ExecuteSteps(hotelSystem.GetHotelReservationSteps(hotelId));
                    else
                        Console.WriteLine("You provided incorrect hotel ID. Please try again.");
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Choose correct option!");
                    return -1;
            }
            return Convert.ToInt32(choice);
        }

        public static void Main()
        {
            var hotelSystem = new HotelSystem();
            hotelSystem.Init();
            var stepsExecutor = new StepsExecutor();

            Console.WriteLine("Welcome to reservation system. Choose option from below.");
            int choice;
            do
            {
                choice = Menu(hotelSystem, stepsExecutor);
            } while (choice != 0);
        }
    }
}
