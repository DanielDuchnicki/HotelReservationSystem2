using FluentAssertions;
using NUnit.Framework;
using HotelReservation;

namespace HotelReservationTests
{
    [TestFixture]
    public class UseCaseFactoryTests
    {
        private UseCaseFactory _subject;

        [SetUp]
        public void BeforeTest()
        {
            _subject = new UseCaseFactory();
        }

        [Test]
        public void ShouldCreateGetHotelsUseCaseInstance()
        {
            _subject.CreateGetHotelsUseCase().Should().BeOfType(typeof(GetHotelsUseCase));
        }

        [Test]
        public void ShouldCreateGetHotelRequiredStepInputsUseCaseInstance()
        {
            _subject.CreateGetHotelRequiredStepInputsUseCase().Should().BeOfType(typeof(GetHotelRequiredStepInputsUseCase));
        }

        [Test]
        public void ShouldCreateReserveHotelUseCaseInstance()
        {
            _subject.CreateReserveHotelUsecase().Should().BeOfType(typeof(ReserveHotelUsecase));
        }
    }
}
