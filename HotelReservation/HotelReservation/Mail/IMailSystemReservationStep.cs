namespace HotelReservation.Mail
{
    public interface IMailSystemReservationStep
    {
        void Execute(IManagementSystem managementSystem);
    }
}
