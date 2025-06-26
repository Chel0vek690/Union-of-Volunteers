using System.Windows;
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
            List<ProjectsApi> data = null;
            try
            {
                data = await _apiClient.GetProjects();
            }
            catch (Exception ex) 
            { 
                MessageBox.Show(ex.Message);
            }
            return data;
        }
    }
}
