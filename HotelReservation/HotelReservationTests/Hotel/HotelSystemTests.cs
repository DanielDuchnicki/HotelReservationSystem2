using NUnit.Framework;
using HotelReservation.Hotel;
using HotelReservation.Mail;
using HotelReservation.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using HotelReservation.Hotel.HotelData;

namespace HotelReservationTests.Hotel
{
    [TestFixture()]
    public class HotelSystemTests
    {
        [Test()]
        public void ShouldAddNewHotelToTheHotelsList()
        {
            HotelSystem hotelSystem = new HotelSystem();
            string hotelName = "TestHotel";
            double price = 100;
            List<IConvertible> hotelReservationSteps = new List<IConvertible>
            {
                HotelReservationSteps.ReservationProcess,
                PaymentReservationSteps.PaymentProcess,
                MailReservationSteps.SendingMailProcess
            };

            hotelSystem.AddNewHotel(hotelName, price, hotelReservationSteps);
            Assert.AreEqual(hotelSystem.Hotels.Count, 1);
        }

        [Test()]
        public void ShouldNewHotelIdBe1000WhenOneNewHotelAdded()
        {
            HotelSystem hotelSystem = new HotelSystem();
            string hotelName = "TestHotel";
            double price = 100;
            List<IConvertible> hotelReservationSteps = new List<IConvertible>
            {
                HotelReservationSteps.ReservationProcess,
                PaymentReservationSteps.PaymentProcess,
                MailReservationSteps.SendingMailProcess
            };

            hotelSystem.AddNewHotel(hotelName, price, hotelReservationSteps);
            Assert.AreEqual(hotelSystem.Hotels.First().HotelId, 1000);
        }

        [Test()]
        public void ShouldAddRecentlyConfiguredHotelToTheHotelList()
        {
            HotelSystem hotelSystem = new HotelSystem();
            HotelData hotelData = new HiltonHotelData();
            hotelSystem.AddConfiguredHotel(hotelData);
            Assert.AreEqual(hotelSystem.Hotels.Count, 1);
        }

        [Test()]
        public void ShouldNewHotelIdBe1000WhenOneRecentlyConfiguredHotelAdded()
        {
            HotelSystem hotelSystem = new HotelSystem();
            HotelData hotelData = new HiltonHotelData();
            hotelSystem.AddConfiguredHotel(hotelData);
            Assert.AreEqual(hotelSystem.Hotels.First().HotelId, 1000);
        }
    }
}