using System;
using System.Collections.ObjectModel;
using HotelReservation.Hotels;
using HotelReservation.ReservationSteps;
using System.Collections.Generic;
using HotelReservation;

namespace ConsoleUserInterface
{
    public class SystemMain
    {
        public static void DisplayMenu()
        {
            Console.WriteLine("\n----==== RESERVATION SYSTEM ====----");
            Console.WriteLine("1 - Start new reservation\n");
            Console.WriteLine("0 - EXIT\n");
            Console.WriteLine("Choose, what you want to do:");
        }

        public static void DisplayHotels(ReadOnlyCollection<Hotel> hotels)
        {
            if (hotels.Count == 0)
                Console.WriteLine("There are no hotels added to the reservation system.");
            else
            {
                Console.WriteLine("[Hotel ID]");
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
            Console.WriteLine("Please provide hotel ID:\n");
            var parsedHotelId = 0;
            return !int.TryParse(Console.ReadLine(), out parsedHotelId) ? 0 : parsedHotelId;
        }

        public static int Menu(ReserveHotelUsecase reserveHotelUsecase)
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
                    DisplayHotels(reserveHotelUsecase.GetHotels());
                    var hotelId = SelectHotel();
                    Console.Clear();
                    try
                    {
                        var stepsList = reserveHotelUsecase.GetHotelReservationSteps(hotelId);
                        var steps = reserveHotelUsecase.CreateStepsInstances(stepsList);
                        var stepInputs = reserveHotelUsecase.GetStepsInputs(steps);
                        var stepInputsToExecute = new List<StepInput>();
                        foreach (var stepInput in stepInputs){
                            Console.WriteLine("Please provide your " + stepInput.Identifier + ": ");
                            stepInput.SetValue(Console.ReadLine());
                            stepInputsToExecute.Add(stepInput);
                        }
                        reserveHotelUsecase.ExecuteSteps(steps, stepInputsToExecute);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
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
            var reserveHotelUsecase = new ReserveHotelUsecase(new HotelSystem(), new StepFactory(), new StepsExecutor());

            Console.WriteLine("Welcome to reservation system. Choose option from below.");
            int choice;
            do
            {
                choice = Menu(reserveHotelUsecase);
            } while (choice != 0);
        }
    }
}
