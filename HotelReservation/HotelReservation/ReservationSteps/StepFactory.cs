using System.Collections.Generic;
using HotelReservation.ReservationSteps.Hotel;
using HotelReservation.ReservationSteps.Mail;
using HotelReservation.ReservationSteps.Payment;

namespace HotelReservation.ReservationSteps
{
    public class StepFactory
    {
        private readonly Dictionary<ReservationStepType, IReservationStep> _reservationStepsInstances;
        public StepFactory()
        {
            _reservationStepsInstances = new Dictionary<ReservationStepType, IReservationStep>
                {
                    {ReservationStepType.ReservationProcess, new ReservationStartProcess() },
                    {ReservationStepType.SendingMailProcess, new SendingMailProcess() },
                    {ReservationStepType.PaymentProcess, new PaymentProcess() }
                };
        }

        public IReservationStep CreateInstance(ReservationStepType reservationStep)
        {
            return _reservationStepsInstances[reservationStep];
        }
    }
}
