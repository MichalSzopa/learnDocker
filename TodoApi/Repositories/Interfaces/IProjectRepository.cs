using TodoApi.Database.Models;

public interface IProjectRepository
{
    Task CreateProject(Project task);

    Task<Project> GetById(int taskId);

    Task<Project[]> GetProjectsForUser(int userId);
}
