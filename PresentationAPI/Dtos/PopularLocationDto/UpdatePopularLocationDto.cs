namespace PresentationAPI.Dtos.PopularLocationDto
{
    public class UpdatePopularLocationDto
    {
        public int location_id { get; set; }
        public string location_name { get; set; }
        public string image { get; set; }
        public bool status { get; set; }
    }
}
