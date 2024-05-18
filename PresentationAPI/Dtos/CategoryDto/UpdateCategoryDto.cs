namespace PresentationAPI.Dtos.CategoryDto
{
    public class UpdateCategoryDto
    {
        public int category_id { get; set; }
        public string category_name { get; set; }
        public bool status { get; set; }
    }
}
