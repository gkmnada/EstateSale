namespace PresentationAPI.Entities
{
    public class EstateDetail
    {
        public int EstateDetailID { get; set; }
        public int EstateSize { get; set; }
        public int Bedroom { get; set; }
        public int Bathroom { get; set; }
        public int Room { get; set; }
        public int GarageSize { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string Location { get; set; }
        public int EstateID { get; set; }
    }
}
