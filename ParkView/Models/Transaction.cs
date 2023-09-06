namespace ParkView.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int UserId { get; set; }
        public int BookingId { get; set; }
        public float TotalPrice { get; set; }
    }
}
