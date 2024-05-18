namespace PresentationAPI.Dtos.EmployeeDto
{
    public class GetEmployeeDto
    {
        public int employee_id { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public string mail { get; set; }
        public string phone { get; set; }
        public string image { get; set; }
        public bool status { get; set; }
    }
}
