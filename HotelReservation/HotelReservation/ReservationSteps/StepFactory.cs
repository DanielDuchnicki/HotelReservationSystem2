﻿using System;
using System.Collections.Generic;
using HotelReservation.ReservationSteps.Reservation;
using HotelReservation.ReservationSteps.Mail;
using HotelReservation.ReservationSteps.Payment;

namespace HotelReservation.ReservationSteps
{
    internal class StepFactory
    {
        private readonly Dictionary<ReservationStepType, Func<IReservationStep>> _reservationStepsInstances;
        public StepFactory()
        {
            _reservationStepsInstances = new Dictionary<ReservationStepType, Func<IReservationStep>>
                {
                    {ReservationStepType.ReservationProcess, () => new ReservationStartProcess()},
                    {ReservationStepType.SendingMailProcess, () => new SendingMailProcess()},
                    {ReservationStepType.PaymentProcess, () => new PaymentProcess()}
                };
        }

        public virtual IReservationStep CreateInstance(ReservationStepType reservationStep)
        {
            Func<IReservationStep> instanceBuilder;
            if (!_reservationStepsInstances.TryGetValue(reservationStep, out instanceBuilder))
            {
                throw new NotImplementedException("There is no implementation of IReservationStep interface for given Reservation Step Type");
            }
            return instanceBuilder();
        }
    }
}
