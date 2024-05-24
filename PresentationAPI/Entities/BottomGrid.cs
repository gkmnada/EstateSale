using System.ComponentModel.DataAnnotations;

namespace PresentationAPI.Entities
{
    public class BottomGrid
    {
        [Key]
        public int bottom_grid_id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }
}
