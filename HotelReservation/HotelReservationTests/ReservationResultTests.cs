using FluentAssertions;
using HotelReservation;
using HotelReservation.ReservationSteps;
using NUnit.Framework;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HotelReservationTests
{
    [TestFixture]
    public class ReservationResultTests
    {
        [Test]
        public void ShouldCreateNewReservationResultWithProvidedResult()
        {
            var reservationResult = new ReservationResult(true, new ReadOnlyCollection<InputType>(new List<InputType>()));
            reservationResult.IsSuccessful.Should().BeTrue();
        }

        [Test]
        public void ShouldCreateNewReservationResultWithProvidedIncorrectInputTypes()
        {
            var incorrectInputTypes = new ReadOnlyCollection<InputType>(new List<InputType> { (InputType)(-1) });

            var reservationResult = new ReservationResult(false, incorrectInputTypes);

            reservationResult.IncorrectInputTypes.Should().BeEquivalentTo(incorrectInputTypes);
        }
    }
}
