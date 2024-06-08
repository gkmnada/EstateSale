using System.ComponentModel.DataAnnotations;

namespace PresentationAPI.Entities
{
    public class SocialMedia
    {
        [Key]
        public int social_media_id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string icon { get; set; }
    }
}
