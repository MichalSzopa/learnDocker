using Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Services.Interfaces;

namespace TodoApi.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class TasksController : ControllerBase
{
    private readonly ITaskService taskService;
    private readonly IHeaderContextService headerContextService;

    public TasksController(ITaskService taskService, IHeaderContextService headerContextService)
    {
        this.taskService = taskService;
        this.headerContextService = headerContextService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoTask>>> Get()
    {
        var userId = headerContextService.GetUserId();
        var tasks = await taskService.GetTasksForUser(userId);

        return Ok(tasks);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateTask(CreateTaskModel model)
    {
        var userId = headerContextService.GetUserId();
        await taskService.CreateNewTask(model, userId);

        return Ok();
    }

    [HttpPost("edit")]
    public async Task<IActionResult> EditTask(EditTaskModel model)
    {
        var userId = headerContextService.GetUserId();
        await taskService.EditTask(model, userId);

        return Ok();
    }
}
