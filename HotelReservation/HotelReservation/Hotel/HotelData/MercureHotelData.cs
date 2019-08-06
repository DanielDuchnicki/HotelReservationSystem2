using System;
using System.Collections.Generic;
using HotelReservation.Payment;

namespace HotelReservation.Hotel.HotelData
{
    public class MercureHotelData : HotelData
    {
        public override string HotelName { get; }
        public override double Price { get; }
        public override List<IConvertible> ReservationStepsData { get; }

        public MercureHotelData()
        {
            HotelName = "Mercure";
            Price = 100;
            ReservationStepsData = new List<IConvertible>
            {
                HotelReservationSteps.ReservationProcess,
                PaymentReservationSteps.PaymentProcess,
            };

        }
    }
}
