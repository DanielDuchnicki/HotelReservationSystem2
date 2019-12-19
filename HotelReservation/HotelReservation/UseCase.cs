using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using HotelReservation.Hotels;
using HotelReservation.ReservationSteps;

namespace HotelReservation
{
    public abstract class UseCase
    {
        public virtual ReadOnlyCollection<Hotel> GetHotels()
        {
            throw new NotImplementedException();
        }


        public virtual void ReserveHotel(int hotelId, List<StepInput> list)
        {
            throw new NotImplementedException();
        }

        public virtual ReadOnlyCollection<StepInput> GetRequiredStepInputsForHotelId(int hotelId)
        {
            throw new NotImplementedException();
        }
    }
}
