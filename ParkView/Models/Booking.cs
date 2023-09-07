using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ParkView.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public string UserId { get; set; }
        public int RoomId { get; set; }
        public string HotelName { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public double TotalPrice { get; set; }
        public int NoOfAdults { get; set; }
        public int NoOfChildrens { get; set; }
        public bool HasOptedCab { get; set; }
        public bool HasOptedFood { get; set; }
        public double RoomPrice { get; set; }
        public double ChildrensPrice { get; set; }
        public double CabPrice { get; set; }
        public double MealPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        

    }
}
