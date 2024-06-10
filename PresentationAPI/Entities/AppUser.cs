using System.ComponentModel.DataAnnotations;

namespace PresentationAPI.Entities
{
    public class AppUser
    {
        [Key]
        public int app_user_id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public int app_role_id { get; set; }
    }
}
