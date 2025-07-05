namespace Union_of_Volunteers.Models
{
    public class ProjectsApi
    {
        public int id { get; set; }
        public string title { get; set; }
        private string _description;
        public string description 
        { 
            get {  return _description; } 
            set {  _description = dataProcessing(value); } 
        }
        public string image { get; set; }

        public string ImageUrl => $"http://api-sdr.itlabs.top{image}";

        private string dataProcessing(string value)
        {
            return value
                    .Replace("<div>", "")
                    .Replace("<br>", "\n")
                    .Replace("</div>", "");
        }


    }
}
