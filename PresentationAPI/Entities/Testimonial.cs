using System.ComponentModel.DataAnnotations;

namespace PresentationAPI.Entities
{
    public class Testimonial
    {
        [Key]
        public int testimonial_id { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public string comment { get; set; }
        public bool status { get; set; }
    }
}
