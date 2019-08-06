using System;
using HotelReservation.Hotel;
using HotelReservation.Mail;
using HotelReservation.Payment;

namespace HotelReservation
{
    public class StepExecutor
    {
        private HotelSystem _hotelSystem;
        private PaymentSystemReservationStepCreator _paymentSystemReservationStepCreator;
        private MailSystemReservationStepCreator _mailSystemReservationStepCreator;

        public StepExecutor(HotelSystem hotelSystem, PaymentSystemReservationStepCreator paymentSystemReservationStepCreator,
            MailSystemReservationStepCreator mailSystemReservationStepCreator)
        {
            _hotelSystem = hotelSystem;
            _paymentSystemReservationStepCreator = paymentSystemReservationStepCreator;
            _mailSystemReservationStepCreator = mailSystemReservationStepCreator;
        }

        public int ExecuteStep(IConvertible reservationStep)
        {
            if (reservationStep.GetType() == typeof(HotelReservationSteps))
            {
                var step = _hotelSystem.StepCreator.ExecuteReservationStepCreation(reservationStep);
                return step.Execute(_hotelSystem);
            }
            else if(reservationStep.GetType() == typeof(MailReservationSteps))
            {
                var step = _mailSystemReservationStepCreator.ExecuteReservationStepCreation(reservationStep);
                step.Execute(_hotelSystem);
                return 0;
            }
            else if (reservationStep.GetType() == typeof(PaymentReservationSteps))
            {
                var step = _paymentSystemReservationStepCreator.ExecuteReservationStepCreation(reservationStep);
                step.Execute(_hotelSystem);
                return 0;
            }

            return 0;
        }
    }
}
