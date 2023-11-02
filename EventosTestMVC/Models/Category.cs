namespace EventosTestMVC.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public ICollection<Supply> Supplies { get; set; }
    }
}
