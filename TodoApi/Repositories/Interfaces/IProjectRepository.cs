using Database.Models;

namespace Repositories.Interfaces;

public interface IProjectRepository : IBaseRepository<Project>
{
    Task CreateProject(Project task);

    Task<Project> GetById(int taskId);

    Task<Project[]> GetProjectsForUser(int userId);
}