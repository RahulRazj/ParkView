namespace ParkView.Models
{
    public enum PaymentStatus
    {
        INITIATED,
        COMPLETE,
        FAILED
    }
    public class Transaction
    {
        public int TransactionId { get; set; }
        public string UserId { get; set; }
        public int BookingId { get; set; }
        public double TotalPrice { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
