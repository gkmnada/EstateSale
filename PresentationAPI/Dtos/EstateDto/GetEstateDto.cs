namespace PresentationAPI.Dtos.EstateDto
{
    public class GetEstateDto
    {
        public int estate_id { get; set; }
        public string title { get; set; }
        public decimal price { get; set; }
        public string image { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string address { get; set; }
        public string description { get; set; }
        public string category_id { get; set; }
        public bool status { get; set; }
    }
}
