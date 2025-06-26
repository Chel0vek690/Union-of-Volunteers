namespace Union_of_Volunteers.Models
{
    public class ProjectsApi
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string image { get; set; }

        public string ImageUrl => $"http://api-sdr.itlabs.top{image}";
    }
}
