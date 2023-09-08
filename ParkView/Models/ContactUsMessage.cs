using System.ComponentModel.DataAnnotations;

namespace ParkView.Models
{
    public class ContactUsMessage
    {
        [Key]
        public int ContactMessageId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
