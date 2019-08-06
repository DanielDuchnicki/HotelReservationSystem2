namespace HotelReservation.Payment
{
    public interface IPaymentSystemReservationStep
    {
        void Execute(IManagementSystem managementSystem);
    }
}
