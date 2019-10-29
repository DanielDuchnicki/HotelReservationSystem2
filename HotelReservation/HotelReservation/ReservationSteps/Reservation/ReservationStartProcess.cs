using System;

namespace HotelReservation.ReservationSteps.Reservation
{
    public class ReservationStartProcess : IReservationStep
    {
        public void Execute(IStepData stepData)
        {
            var reservationStartProcessData = stepData as ReservationStartProcessData;
            Console.WriteLine("----==== RESERVATION PROCESS ====----");
            Console.WriteLine(reservationStartProcessData.HotelId);
        }
    }
}
