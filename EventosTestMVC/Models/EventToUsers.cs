using System.ComponentModel.DataAnnotations;

namespace EventosTestMVC.Models
{
    public class EventToUsers
    {
        [Key]
        public int Id { get; set; }
        public string UserEmail { get; set; }
        public Guid EventId { get; set; }

        public User User { get; set; }
        public Event Event { get; set; }
    }
}
