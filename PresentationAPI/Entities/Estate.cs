namespace PresentationAPI.Entities
{
    public class Estate
    {
        public int EstateID { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string CategoryID { get; set; }
        public bool Status { get; set; }
    }
}
