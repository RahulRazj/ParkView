using ParkView.Models.IRepositories;

namespace ParkView.Models.DbRepos
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

        public Booking? GetBookingById(int id) => _dbContext.Bookings.SingleOrDefault(booking => booking.BookingId == id);

        public void UpdateBooking(Booking booking)
        {
            _dbContext.Bookings.Update(booking);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Booking> GetCompletedBookings(string userId) => _dbContext.Bookings.Where(booking => booking.UserId == userId && booking.IsBookingComplete).OrderByDescending(booking => booking.CreatedAt);
    }
}
