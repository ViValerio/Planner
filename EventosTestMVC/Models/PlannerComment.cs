
namespace EventosTestMVC.Models
{
    public class PlannerComment
    {
        public int Id { get; set; }
        public string TextComment { get; set; }
        public DateTime PublishDate { get; set; }
        //fks
        public string? PlannerEmail { get; set; }
        public Guid? EventId { get; set; }

        //navprops
        public Planner Planner { get; set; }
        public Event Event { get; set; }
    }
}
