namespace PresentationUI.Dtos.TestimonialDto
{
    public class UpdateTestimonialDto
    {
        public int testimonial_id { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public string comment { get; set; }
        public bool status { get; set; }
    }
}
