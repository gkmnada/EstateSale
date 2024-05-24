using System.ComponentModel.DataAnnotations;

namespace PresentationAPI.Entities
{
    public class PopularLocation
    {
        [Key]
        public int location_id { get; set; }
        public string location_name { get; set; }
        public string image { get; set; }
        public bool status { get; set; }
    }
}
