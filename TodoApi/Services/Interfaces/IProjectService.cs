using TodoApi.Database.Models;

public interface IProjectService
{
    Task<Project[]> GetProjectsForUser(int userId);

    Task CreateNewProject(CreateProjectModel model, int userId);

    Task EditProject(EditProjectModel model, int userId);

    Task<Project> GetProjectById(int projectId);
}
