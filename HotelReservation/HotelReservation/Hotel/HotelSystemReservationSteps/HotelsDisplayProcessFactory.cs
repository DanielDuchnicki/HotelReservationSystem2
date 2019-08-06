namespace HotelReservation.Hotel.HotelSystemReservationSteps
{
    public class HotelsDisplayProcessFactory : HotelSystemReservationStepsFactory
    {
        public override IHotelSystemReservationStep Create() => new HotelsDisplayProcess();
    }
}
