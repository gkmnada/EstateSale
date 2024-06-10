using System.ComponentModel.DataAnnotations;

namespace PresentationAPI.Entities
{
    public class AppRole
    {
        [Key]
        public int app_role_id { get; set; }
        public string role_name { get; set; }
    }
}
