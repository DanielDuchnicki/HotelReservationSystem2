using System.Collections.Generic;
using HotelReservation.ReservationSteps.Hotel;
using HotelReservation.ReservationSteps.Mail;
using HotelReservation.ReservationSteps.Payment;

namespace HotelReservation.ReservationSteps
{
    public class StepsExecutor
    {
        private readonly Dictionary<ReservationStepType, IReservationStep> _reservationStepsInstances;

        public StepsExecutor()
        {
            _reservationStepsInstances = new Dictionary<ReservationStepType, IReservationStep>
                {
                    {ReservationStepType.ReservationProcess, new ReservationStartProcess() },
                    {ReservationStepType.SendingMailProcess, new SendingMailProcess() },
                    {ReservationStepType.PaymentProcess, new PaymentProcess() }
                };
        }

        public void ExecuteSteps(List<ReservationStepType> reservationSteps)
        {
            foreach (var reservationStep in reservationSteps)
            {
                _reservationStepsInstances[reservationStep].Execute();
            }
        }
    }
}

