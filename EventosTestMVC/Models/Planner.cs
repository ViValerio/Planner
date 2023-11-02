using System.ComponentModel.DataAnnotations;

namespace EventosTestMVC.Models
{
    public class Planner
    {
        [Key]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int? AvatarPlannerId { get; set; }

        //nav props for avatar ralation 1 to 1
        public AvatarPlanner AvatarPlanner { get; set; }

        //nav props for event ralation 1 to m
        public IEnumerable<Event> Events { get; set; }

        //nav props for comment ralation 1 to m
        public ICollection<PlannerComment> PlannerComments { get; set; }


    }
}