namespace ParkView.Models.IRepositories
{
    public interface IBookingRepo
    {
        void SaveBooking(Booking booking);
        Booking? GetBookingById(int id);
        void UpdateBooking(Booking booking);

        IEnumerable<Booking> GetCompletedBookings(string userId);
    }
}
