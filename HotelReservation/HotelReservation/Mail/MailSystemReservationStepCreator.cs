using System;
using System.Collections.Generic;

namespace HotelReservation.Mail
{
    public class MailSystemReservationStepCreator
    {
        private readonly Dictionary<IConvertible, MailSystemReservationStepsFactory> _reservationStepsFactories;

        public MailSystemReservationStepCreator()
        {
            _reservationStepsFactories = new Dictionary<IConvertible, MailSystemReservationStepsFactory>
            {
                {MailReservationSteps.SendingMailProcess, new SendingMailProcessFactory() },
            };
        }

        public IMailSystemReservationStep ExecuteReservationStepCreation(IConvertible reservationStep) =>
            _reservationStepsFactories[reservationStep].Create();
    }
}
