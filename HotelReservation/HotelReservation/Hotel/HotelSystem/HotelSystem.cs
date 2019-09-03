using System.Collections.Generic;

namespace HotelReservation.Hotel.HotelSystem
{
    public class HotelSystem
    {
        public List<Hotel> Hotels = new List<Hotel>();
        private int LastHotelId { get; set; } = 1000;

        public void AddNewHotel(List<ReservationSteps.ReservationSteps> hotelReservationSteps)
        {
            var hotelId = LastHotelId;
            var newHotel = new Hotel(hotelId, hotelReservationSteps);
            Hotels.Add(newHotel);
            LastHotelId++;
        }

        public List<ReservationSteps.ReservationSteps> GetHotelReservationSteps(int hotelId)
        {
            return Hotels.Find(hotel => hotel.HotelId == hotelId).ReservationSteps;
        }

        public void Init()
        {
            var firstHotelReservationSteps = new List<ReservationSteps.ReservationSteps>()
            {
                ReservationSteps.ReservationSteps.ReservationProcess,
                ReservationSteps.ReservationSteps.PaymentProcess,
                ReservationSteps.ReservationSteps.SendingMailProcess
            };
            var secondHotelReservationSteps = new List<ReservationSteps.ReservationSteps>()
            {
                ReservationSteps.ReservationSteps.ReservationProcess,
                ReservationSteps.ReservationSteps.SendingMailProcess
            };
            AddNewHotel(firstHotelReservationSteps);
            AddNewHotel(secondHotelReservationSteps);
        }
    }
}
