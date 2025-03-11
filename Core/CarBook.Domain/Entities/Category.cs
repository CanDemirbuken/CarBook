namespace CarBook.Domain.Entities
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }

        // Relationship
        public List<Blog> Blogs { get; set; }
    }
}
