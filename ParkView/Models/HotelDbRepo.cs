using Microsoft.EntityFrameworkCore;

namespace ParkView.Models
{
    public class HotelDbRepo : IHotelRepo
    {
        private readonly ApplicationDbContext _dbContext;

        public HotelDbRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Hotel> AllHotels => _dbContext.Hotels.OrderBy(hotel => hotel.HotelName).Include(hotel => hotel.Location).Include(hotel => hotel.Rooms).ThenInclude(room => room.RoomType);

        public IEnumerable<Location> AllLocations => _dbContext.Locations.OrderBy(location => location.City);

        public Hotel? GetHotelById(int id) => AllHotels.SingleOrDefault(hotel => hotel.HotelId == id);

        public IEnumerable<Hotel> GetHotelsByLocation(string locationCode) => AllHotels.Where(hotel => hotel.Location.LocationCode == locationCode);

        public IEnumerable<Hotel> SearchHotels(string query)
        {
            return AllHotels.Where(hotel => hotel.HotelName.ToLower().Contains(query.ToLower()) || hotel.Location.City.ToLower().Contains(query.ToLower()));
        }
    }
}
