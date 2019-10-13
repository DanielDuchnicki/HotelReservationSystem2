using System;
using System.Collections.Generic;
using HotelReservation.ReservationSteps.Hotel;
using HotelReservation.ReservationSteps.Mail;
using HotelReservation.ReservationSteps.Payment;

namespace HotelReservation.ReservationSteps
{
    public class StepFactory
    {
        private readonly Dictionary<ReservationStepType, Type> _reservationStepsInstances;
        public StepFactory()
        {
            
            _reservationStepsInstances = new Dictionary<ReservationStepType, Type>
                {
                    {ReservationStepType.ReservationProcess, typeof(ReservationStartProcess)},
                    {ReservationStepType.SendingMailProcess, typeof(SendingMailProcess)},
                    {ReservationStepType.PaymentProcess, typeof(PaymentProcess)}
                };
        }

        public IReservationStep CreateInstance(ReservationStepType reservationStep)
        {
            Type instance;
            if (!_reservationStepsInstances.TryGetValue(reservationStep, out instance))
            {
                throw new NotImplementedException("There is no implementation of IReservationStep interface for given Reservation Step Type");
            }
            return (IReservationStep)Activator.CreateInstance(instance);
        }
    }
}
