using System;
using System.Collections.Generic;
using System.Linq;
using HotelReservation.Hotels;
using HotelReservation.ReservationSteps;
using FluentAssertions;
using NUnit.Framework;

namespace HotelReservationTests.Hotels
{
    [TestFixture]
    public class HotelSystemTests
    {
        HotelSystem _subject;

        [SetUp]
        public void BeforeTest()
        {
            _subject = new HotelSystem();
        }

        [Test]
        public void ShouldAddNewHotelToTheHotelsList()
        {
            _subject.AddNewHotel(new List<ReservationStepType>());
            _subject.GetHotels().Should().HaveCount(1);
        }

        [Test]
        public void ShouldFirstAddedHotelHasIdEqual1()
        {
            _subject.AddNewHotel(new List<ReservationStepType>());
            _subject.GetHotels().First().HotelId.Should().Be(1);
        }

        [Test]
        public void ShouldIdsBeIncrementedForEachAddedHotel()
        {
            for (var counter = 1; counter <= 5; counter++)
            {
                _subject.AddNewHotel(new List<ReservationStepType>());
            }
            _subject.GetHotels().Last().HotelId.Should().Be(5);
        }

        [Test]
        public void ShouldProvideHotelReservationStepsList()
        {
            var reservationSteps = new List<ReservationStepType>()
            {
                ReservationStepType.ReservationProcess,
                ReservationStepType.PaymentProcess
            };
            _subject.AddNewHotel(reservationSteps);
            _subject.GetHotelReservationSteps(1).Should().BeEquivalentTo(reservationSteps);
        }

        [Test]
        public void ShouldThrowArgumentExceptionWhenIncorrectHotelIdProvided()
        {
            Action act = () => _subject.GetHotelReservationSteps(-5);
            act.Should().Throw<Exception>().WithMessage("You provided incorrect hotel ID. Please try again.");
        }

        [Test]
        public void ShouldLastHotelIdEqual1WhenOneHotelAdded()
        {
            _subject.AddNewHotel(new List<ReservationStepType>());
            _subject.LastHotelId.Should().Be(1);
        }

        [Test]
        public void ShouldLastHotelIdBeIncrementedForEachAddedHotel()
        {
            for (var counter = 1; counter <= 5; counter++)
            {
                _subject.AddNewHotel(new List<ReservationStepType>());
            }
            _subject.LastHotelId.Should().Be(5);
        }

        [Test]
        public void ShouldLastHotelIdBe0WhenNoHotelsAdded()
        {
            _subject.LastHotelId.Should().Be(0);
        }
    }
}