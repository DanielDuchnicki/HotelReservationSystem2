using System;
using System.Collections.Generic;
using HotelReservation.Mail;
using HotelReservation.Payment;

namespace HotelReservation.Hotel.HotelData
{
    public class HiltonHotelData : HotelData
    {
        public override string HotelName { get; }
        public override double Price { get; }
        public override List<IConvertible> ReservationStepsData { get; }

        public HiltonHotelData()
        {
            HotelName = "Hilton";
            Price = 400;
            ReservationStepsData = new List<IConvertible>
            {
                HotelReservationSteps.ReservationProcess,
                PaymentReservationSteps.PaymentProcess,
                MailReservationSteps.SendingMailProcess,
            };

        }
    }
}