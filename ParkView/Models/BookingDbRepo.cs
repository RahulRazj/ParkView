namespace ParkView.Models
{
    public class BookingDbRepo : IBookingRepo
    {
        private readonly ApplicationDbContext _dbContext;

        public BookingDbRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void SaveBooking(Booking booking)
        {
            _dbContext.Bookings.Add(booking);
            _dbContext.SaveChanges();
        }
    }
}
