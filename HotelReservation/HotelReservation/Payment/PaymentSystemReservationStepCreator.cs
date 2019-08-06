using System;
using System.Collections.Generic;

namespace HotelReservation.Payment
{
    public class PaymentSystemReservationStepCreator
    {
        private readonly Dictionary<IConvertible, PaymentSystemReservationStepsFactory> _reservationStepsFactories;

        public PaymentSystemReservationStepCreator()
        {
            _reservationStepsFactories = new Dictionary<IConvertible, PaymentSystemReservationStepsFactory>
            {
                {PaymentReservationSteps.PaymentProcess, new PaymentProcessFactory() },
            };
        }

        public IPaymentSystemReservationStep ExecuteReservationStepCreation(IConvertible reservationStep) =>
            _reservationStepsFactories[reservationStep].Create();
    }
}
