namespace PresentationAPI.Dtos.ContactDto
{
    public class ResultContactDto
    {
        public int contact_id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string message { get; set; }
        public DateTime created_at { get; set; }
    }
}
