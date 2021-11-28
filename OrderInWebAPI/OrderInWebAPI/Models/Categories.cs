namespace OrderInWebAPI.Models
{
    public class Categories
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<MenuItem> MenuItems { get; set;}
    }
}
