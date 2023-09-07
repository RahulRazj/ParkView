namespace ParkView.Models
{
    public interface IRoomRepo
    {
        IEnumerable<Room> AllRooms { get; }
        Room? GetRoomById(int id);
    }
}
