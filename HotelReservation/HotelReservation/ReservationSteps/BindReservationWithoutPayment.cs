using System;

namespace HotelReservation.ReservationSteps
{
    class BindReservationWithoutPayment : IReservationStep
    {
        public void Execute()
        {
            Console.WriteLine("----==== BINDING RESERVATION WITHOUT PAYMENT ====----");
        }
    }
}
