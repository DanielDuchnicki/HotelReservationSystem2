using System;

namespace HotelReservation
{
    public class ConsolePrinter
    {
        public virtual void Execute(string message)
        {
            Console.WriteLine(message);
        }
    }
}
