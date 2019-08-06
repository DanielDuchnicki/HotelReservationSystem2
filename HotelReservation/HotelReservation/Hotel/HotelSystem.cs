using System;
using System.Collections.Generic;
using HotelReservation.Hotel.HotelSystemReservationSteps;

namespace HotelReservation.Hotel
{
    public class HotelSystem : IManagementSystem
    {
        public List<Hotel> Hotels = new List<Hotel>();
        public HotelSystemReservationStepCreator StepCreator = new HotelSystemReservationStepCreator();

        public void AddNewHotel(string hotelName, double price, List<IConvertible> hotelReservationSteps)
        {
            int hotelId = Hotels.Count + 1000;
            Hotel newHotel = new Hotel(hotelId, hotelName, price, hotelReservationSteps);
            Hotels.Add(newHotel);
        }
        public void AddConfiguredHotel(HotelData.HotelData hotelData)
        {
            int hotelId = Hotels.Count + 1000;
            Hotel newHotel = new Hotel(hotelId, hotelData.HotelName, hotelData.Price, hotelData.ReservationStepsData);
            Hotels.Add(newHotel);
        }
    }
}
