namespace ParkView.Models
{
    public class BookingDetails
    {
        public double GrandTotal { get; set; }
        public int NoOfAdults { get; set; }
        public int NoOfChildrens { get; set; }
        public DateTime CheckinDate { get; set; }
        public DateTime CheckOutDate { get; set; }
    }
}
