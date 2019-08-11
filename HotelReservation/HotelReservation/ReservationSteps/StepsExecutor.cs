using System.Collections.Generic;
using HotelReservation.ReservationSteps.Hotel;
using HotelReservation.ReservationSteps.Mail;
using HotelReservation.ReservationSteps.Payment;

namespace HotelReservation.ReservationSteps
{
    public class StepsExecutor
    {
        private readonly Dictionary<ReservationSteps, IReservationStep> _reservationStepsInstances;

        public StepsExecutor()
        {
            _reservationStepsInstances = new Dictionary<ReservationSteps, IReservationStep>
                {
                    {ReservationSteps.ReservationProcess, new ReservationStartProcess() },
                    {ReservationSteps.SendingMailProcess, new SendingMailProcess() },
                    {ReservationSteps.PaymentProcess, new PaymentProcess() }
                };
        }

        public void ExecuteSteps(List<ReservationSteps> reservationSteps)
        {
            foreach (var reservationStep in reservationSteps)
            {
                _reservationStepsInstances[reservationStep].Execute();
            }
        }
    }
}

