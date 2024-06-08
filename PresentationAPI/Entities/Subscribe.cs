using System.ComponentModel.DataAnnotations;

namespace PresentationAPI.Entities
{
    public class Subscribe
    {
        [Key]
        public int subscribe_id { get; set; }
        public string email { get; set; }
    }
}
