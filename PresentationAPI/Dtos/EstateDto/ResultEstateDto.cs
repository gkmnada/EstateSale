namespace PresentationAPI.Dtos.EstateDto
{
    public class ResultEstateDto
    {
        public int estate_id { get; set; }
        public string title { get; set; }
        public decimal price { get; set; }
        public string image { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string address { get; set; }
        public string description { get; set; }
        public string sales_type { get; set; }
        public int category_id { get; set; }
        public int employee_id { get; set; }
        public bool deal_of_day { get; set; }
        public bool status { get; set; }
        public int app_user_id { get; set; }
    }
}
