using System.ComponentModel.DataAnnotations;

namespace PresentationAPI.Entities
{
    public class Service
    {
        [Key]
        public int service_id { get; set; }
        public string service_name { get; set; }
        public bool status { get; set; }
    }
}
