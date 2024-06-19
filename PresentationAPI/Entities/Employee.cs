using System.ComponentModel.DataAnnotations;

namespace PresentationAPI.Entities
{
    public class Employee
    {
        [Key]
        public int employee_id { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public string mail { get; set; }
        public string phone { get; set; }
        public string image { get; set; }
        public bool status { get; set; }
        public int app_user_id { get; set; }
    }
}
