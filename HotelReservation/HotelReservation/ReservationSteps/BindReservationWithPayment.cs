using System;

namespace HotelReservation.ReservationSteps
{
    class BindReservationWithPayment : IReservationStep
    {
        public void Execute()
        {
            Console.WriteLine("----==== BINDING RESERVATION WITH PAYMENT ====----");
        }
    }
}
