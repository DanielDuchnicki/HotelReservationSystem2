using System;
using System.Collections.Generic;

namespace HotelReservation.ReservationSteps
{
    public class ReservationStepCreator
    {
        private readonly Dictionary<ReservationSteps, ReservationStepsFactory> _reservationStepsFactories;

        public ReservationStepCreator()
        {
            _reservationStepsFactories = new Dictionary<ReservationSteps, ReservationStepsFactory>
            {
                {ReservationSteps.AcceptPayment, new AcceptPaymentFactory() },
                {ReservationSteps.BindReservationWithPayment, new BindReservationWithPaymentFactory() },
                {ReservationSteps.BindReservationWithoutPayment, new BindReservationWithoutPaymentFactory() },
                {ReservationSteps.ChangeHotelPrice, new ChangeHotelPriceFactory() },
                {ReservationSteps.CheckHotelPrice, new CheckHotelPriceFactory() },
                {ReservationSteps.CreateMail, new CreateMailFactory() },
                {ReservationSteps.DisplayHotels, new DisplayHotelsFactory() },
                {ReservationSteps.DisplayMails, new DisplayMailsFactory() },
                {ReservationSteps.DisplayPayments, new DisplayPaymentsFactory() },
                {ReservationSteps.DisplayReservations, new DisplayReservationsFactory() },
                {ReservationSteps.SelectHotel, new SelectHotelFactory() },
                {ReservationSteps.SendMail, new SendMailFactory() },
                {ReservationSteps.StartNewPayment, new StartNewPaymentFactory() },
                {ReservationSteps.StartNewReservation, new StartNewReservationFactory() }
            };
        }

        public IReservationStep ExecuteReservationStepCreation(ReservationSteps reservationStep) =>
            _reservationStepsFactories[reservationStep].Create();
    }
}
