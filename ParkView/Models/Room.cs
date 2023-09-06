using MessagePack;

namespace ParkView.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public int HotelId { get; set; }
        public int RoomTypeId { get; set; }
        public int TotalRoomsAvailable { get; set; }
        public int PricePerNight { get; set; }
        public RoomType RoomType { get; set; }
    }
}
