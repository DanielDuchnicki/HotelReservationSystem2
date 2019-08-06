using System;
using HotelReservation.Hotel;
using HotelReservation.Hotel.HotelData;
using HotelReservation.Mail;
using HotelReservation.Payment;

namespace HotelReservation
{
    class SystemMain
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

        public static int Menu(HotelSystem hotelSystem, StepExecutor stepExecutor)
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
                    stepExecutor.ExecuteStep(HotelReservationSteps.HotelsDisplayProcess);
                    var hotelId = stepExecutor.ExecuteStep(HotelReservationSteps.SelectingHotelProcess);
                    var selectedHotel = hotelSystem.Hotels.Find(hotel => hotel.HotelId == hotelId);
                    foreach (IConvertible reservationStep in selectedHotel.ReservationSteps)
                    {
                        stepExecutor.ExecuteStep(reservationStep);
                    }
                    Console.ReadKey();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Choose correct option!");
                    break;
            }
            return Convert.ToInt32(choice);
        }

        static void Main()
        {
            var hotelSystem = new HotelSystem();
            var paymentSystemReservationStepCreator = new PaymentSystemReservationStepCreator();
            var mailSystemReservationStepCreator = new MailSystemReservationStepCreator();

            hotelSystem.AddConfiguredHotel(new MercureHotelData());
            hotelSystem.AddConfiguredHotel(new HiltonHotelData());

            var stepExecutor = new StepExecutor(hotelSystem, paymentSystemReservationStepCreator, mailSystemReservationStepCreator);

            Console.WriteLine("Welcome to reservation system. Choose option from below.");
            int choice;
            do
            {
                choice = Menu(hotelSystem, stepExecutor);
            } while (choice != 0);
        }
    }
}
