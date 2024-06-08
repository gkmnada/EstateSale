using System.ComponentModel.DataAnnotations;

namespace PresentationAPI.Entities
{
    public class Address
    {
        [Key]
        public int address_id { get; set; }
        public string address_detail { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
    }
}
