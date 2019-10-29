using System;

namespace HotelReservation.ReservationSteps.Payment
{
    public class PaymentProcess : IReservationStep
    {
        public void Execute(IStepData stepData)
        {
            var paymentProcessData = stepData as PaymentProcessData;
            Console.WriteLine("----==== PAYMENT PROCESS ====----");
            Console.WriteLine(paymentProcessData.Price);
        }
    }
}
