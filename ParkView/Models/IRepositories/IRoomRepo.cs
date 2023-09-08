namespace ParkView.Models.IRepositories
{
    public interface IRoomRepo
    {
        IEnumerable<Room> AllRooms { get; }
        Room? GetRoomById(int id);

        void UpdateRoom(Room room);
    }


}
