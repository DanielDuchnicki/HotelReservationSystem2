using System;
using HotelReservation.ReservationSteps;

namespace HotelReservation
{
    class SystemMain
    {
        static void Main()
        {
            foreach (ReservationSteps.ReservationSteps reservationStep in Enum.GetValues(typeof(ReservationSteps.ReservationSteps)))
            {
                var stepRunner = new ReservationStepCreator().ExecuteReservationStepCreation(reservationStep);
                stepRunner.Execute();
            }
            Console.ReadKey();
        }
    }
}
