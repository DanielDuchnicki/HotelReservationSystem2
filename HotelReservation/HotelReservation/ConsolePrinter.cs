using System;

namespace HotelReservation
{
    public class ConsolePrinter
    {
        public virtual void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
