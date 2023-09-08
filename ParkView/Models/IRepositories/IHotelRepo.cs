namespace ParkView.Models.IRepositories
{
    public interface IHotelRepo
    {
        IEnumerable<Hotel> AllHotels { get; }

        Hotel? GetHotelById(int id);

        IEnumerable<Hotel> SearchHotels(string query);

        IEnumerable<Hotel> GetHotelsByLocation(string locationCode);
        IEnumerable<Location> AllLocations { get; }
    }
}
