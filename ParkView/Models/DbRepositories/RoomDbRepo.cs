using Microsoft.EntityFrameworkCore;
using ParkView.Models.IRepositories;

namespace ParkView.Models.DbRepos
{
    public class RoomDbRepo : IRoomRepo
    {
        private readonly ApplicationDbContext _dbContext;


        public RoomDbRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Room> AllRooms => _dbContext.Rooms.Where(room => room.TotalRoomsAvailable > 0).OrderBy(room => room.HotelId).Include(room => room.RoomType);

        public Room? GetRoomById(int id) => AllRooms.SingleOrDefault(room => room.RoomId == id && room.TotalRoomsAvailable > 0);

        public void UpdateRoom(Room room)
        {
            _dbContext.Rooms.Update(room);
            _dbContext.SaveChanges();
        }
    }
}
