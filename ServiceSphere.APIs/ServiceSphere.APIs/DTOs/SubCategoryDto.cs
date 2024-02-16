namespace ServiceSphere.APIs.DTOs
{
    public class SubCategoryDto
    {
        public string Name { get; set; }
        //foreign key for category
        public int CategoryId { get; set; }
    }
}
