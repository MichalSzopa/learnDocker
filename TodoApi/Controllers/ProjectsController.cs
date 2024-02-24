using Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Services.Interfaces;

namespace TodoApi.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly IProjectService projectService;
    private readonly IHeaderContextService headerContextService;

    public ProjectsController(IProjectService projectService, IHeaderContextService headerContextService)
    {
        this.projectService = projectService;
        this.headerContextService = headerContextService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoTask>>> Get()
    {
        var userId = headerContextService.GetUserId();
        var projects = await projectService.GetProjectsForUser(userId);

        return Ok(projects);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateProject(CreateProjectModel model)
    {
        var userId = headerContextService.GetUserId();
        await projectService.CreateNewProject(model, userId);

        return Ok();
    }

    [HttpPost("edit")]
    public async Task<IActionResult> EditProject(EditProjectModel model)
    {
        var userId = headerContextService.GetUserId();
        await projectService.EditProject(model, userId);

        return Ok();
    }
}
