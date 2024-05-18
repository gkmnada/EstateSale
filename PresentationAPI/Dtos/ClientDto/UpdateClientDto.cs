namespace PresentationAPI.Dtos.ClientDto
{
    public class UpdateClientDto
    {
        public int client_id { get; set; }
        public string client_name { get; set; }
        public string title { get; set; }
        public string comment { get; set; }
        public bool status { get; set; }
    }
}
