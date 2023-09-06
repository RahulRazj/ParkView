using System.ComponentModel.DataAnnotations;

namespace ParkView.Models
{
    public class Hotel
    {
        public int HotelId { get; set; }
        [Required(ErrorMessage = "Hotel name is required")]
        public string HotelName { get; set; }
        [Required(ErrorMessage = "Description is requires")]
        public string Description { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public IEnumerable<Room> Rooms { get; set; }

    }
}
