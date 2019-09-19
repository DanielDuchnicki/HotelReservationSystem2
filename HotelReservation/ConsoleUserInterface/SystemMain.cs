using System;
using System.Collections.Generic;
using HotelReservation.Hotels;
using HotelReservation.ReservationSteps;

namespace ConsoleUserInterface
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

        public static void DisplayHotels(List<Hotel> hotels)
        {
            if (hotels.Count == 0)
                Console.WriteLine("There are no hotels added to the reservation system.");
            else
            {
                Console.WriteLine("[Hotel ID, Name, Price (for each day), Is free?]");
                foreach (var hotel in hotels)
                {
                    Console.WriteLine("Hotel ID: " + hotel.HotelId);
                }
            }
            Console.WriteLine();
        }
        public static int SelectHotel()
        {
            Console.WriteLine("Please check list of hotels and choose one for you!");
            Console.WriteLine("Please provide hotel ID: ");
            var selectedHotelId = Console.ReadLine();
            var parsedHotelId = 0;
            Console.WriteLine();
            return !int.TryParse(selectedHotelId, out parsedHotelId) ? 0 : parsedHotelId;
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
                    var hotels = hotelSystem.GetHotels();
                    DisplayHotels(hotels);
                    var hotelId = SelectHotel();
                    Console.Clear();
                    if (hotelId >= 1000 & hotelId < hotelSystem.LastHotelId)
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
            new SystemInit().AddHotels(hotelSystem);
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
