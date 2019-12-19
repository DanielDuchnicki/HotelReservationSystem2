using System;
using FluentAssertions;
using NUnit.Framework;
using HotelReservation;

namespace HotelReservationTests
{
    [TestFixture]
    class UseCaseFactoryTests
    {
        UseCaseFactory _subject;

        [SetUp]
        public void BeforeTest()
        {
            _subject = new UseCaseFactory();
        }

        [Test]
        public void ShouldCreateGetHotelsUseCaseInstance()
        {
            _subject.CreateInstance(UseCaseType.GetHotels).Should().BeOfType(typeof(GetHotelsUseCase));
        }

        [Test]
        public void ShouldCreateGetHotelRequiredStepInputsUseCaseInstance()
        {
            _subject.CreateInstance(UseCaseType.GetHotelRequiredStepInputs).Should().BeOfType(typeof(GetHotelRequiredStepInputsUseCase));
        }

        [Test]
        public void ShouldCreateReserveHotelUseCaseInstance()
        {
            _subject.CreateInstance(UseCaseType.ReserveHotel).Should().BeOfType(typeof(ReserveHotelUsecase));
        }

        [Test]
        public void ShouldThrowExceptionForNotValidReservationStep()
        {
            Action act = () => _subject.CreateInstance((UseCaseType)(-1));
            act.Should().Throw<NotImplementedException>().WithMessage("There is no implementation of UseCase class for given UseCase Type");
        }
    }
}
