using System;

namespace HotelReservation.ReservationSteps
{
    class CreateMail : IReservationStep
    {
        public void Execute()
        {
            Console.WriteLine("----==== CREATING MAIL ====----");
        }
    }
}
