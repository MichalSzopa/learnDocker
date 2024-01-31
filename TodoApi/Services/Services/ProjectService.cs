using TodoApi.Database.Models;

public class ProjectService : IProjectService
{
    private readonly UnitOfWork unitOfWork;

    public ProjectService(UnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task CreateNewProject(CreateProjectModel model, int userId)
    {
        var project = new Project 
        {
            Title = model.Title,
            Description = model.Description,
            CategoryId = model.CategoryId,
            UserId = userId
        };

        await unitOfWork.ProjectRepository.CreateProject(project);
    }

    public async Task EditProject(EditProjectModel model, int userId)
    {
        var project = await unitOfWork.ProjectRepository.GetById(model.Id);

        project.Description = model.Description;
        project.Title = model.Title;
        project.CategoryId = model.CategoryId;

        await unitOfWork.SaveChanges();
    }

    public async Task<Project> GetProjectById(int projectId)
    {
        var project = await unitOfWork.ProjectRepository.GetById(projectId);

        return project;
    }

    public async Task<Project[]> GetProjectsForUser(int userId)
    {
        return await unitOfWork.ProjectRepository.GetProjectsForUser(userId);
    }
}