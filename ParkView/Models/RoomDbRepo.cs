using Microsoft.EntityFrameworkCore;

namespace ParkView.Models
{
    public class RoomDbRepo : IRoomRepo
    {
        private readonly ApplicationDbContext _dbContext;


        public RoomDbRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Room> AllRooms => _dbContext.Rooms.OrderBy(room => room.HotelId).Include(room => room.RoomType);

        public Room? GetRoomById(int id) => AllRooms.SingleOrDefault(room => room.RoomId == id);
    }
}
