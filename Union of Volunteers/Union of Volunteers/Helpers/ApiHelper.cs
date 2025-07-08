using Union_of_Volunteers.Models;
using Union_of_Volunteers.Models.Interfaces;

namespace Union_of_Volunteers.Helpers
{
    public class ApiHelper
    {
        private readonly Api _apiClient;

        public ApiHelper(Api apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<List<ProjectsApi>> GetProjects()
        {
            List<ProjectsApi> data = await _apiClient.GetProjects();
            return data;
        }
    }
}