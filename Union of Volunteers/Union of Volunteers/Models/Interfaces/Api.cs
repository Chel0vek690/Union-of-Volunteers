using Refit;

namespace Union_of_Volunteers.Models.Interfaces
{
    public interface Api
    {
        [Get("/api/projects")]
        Task<List<ProjectsApi>> GetProjects();
    }
}