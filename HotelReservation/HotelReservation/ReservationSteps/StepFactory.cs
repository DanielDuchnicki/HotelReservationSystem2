using System;
using System.Collections.Generic;
using HotelReservation.ReservationSteps.Hotel;
using HotelReservation.ReservationSteps.Mail;
using HotelReservation.ReservationSteps.Payment;

namespace HotelReservation.ReservationSteps
{
    public class StepFactory
    {
        private readonly Dictionary<ReservationStepType, Func<IReservationStep>> _reservationStepsInstances;
        public StepFactory()
        {
            
            _reservationStepsInstances = new Dictionary<ReservationStepType, Func<IReservationStep>>
                {
                    {ReservationStepType.ReservationProcess, (() => new ReservationStartProcess())},
                    {ReservationStepType.SendingMailProcess, (() => new SendingMailProcess())},
                    {ReservationStepType.PaymentProcess, (() => new PaymentProcess())}
                };
        }

        public virtual IReservationStep CreateInstance(ReservationStepType reservationStep)
        {
            Func<IReservationStep> instance;
            if (!_reservationStepsInstances.TryGetValue(reservationStep, out instance))
            {
                throw new NotImplementedException("There is no implementation of IReservationStep interface for given Reservation Step Type");
            }
            return instance.Invoke();
        }
    }
}
