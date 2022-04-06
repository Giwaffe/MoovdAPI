namespace MoovdAPI.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; }
        public Category ParentCategory { get; }

        public Category()
        {
        }

        public Category(string name)
        {
            Name = name;
        }
        public Category(string name, Category parentCategory)
        {
            Name = name;
            ParentCategory = parentCategory;
        }
    }
}