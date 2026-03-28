using Api.Controllers.Tasks.Response;
using Api.Controllers.Users.Response;
using Api.UseCases.Tasks.Interfaces;
using Dal.Entities;
using Logic.Tasks.Services.Interfaces;
using Logic.Users.Services.Interfaces;
using System.Xml.Linq;

namespace Api.UseCases.Tasks;

public class CreateTaskUseCase : ICreateTaskUseCase
{
    private readonly ITaskService _taskService;

    public CreateTaskUseCase(ITaskService taskService)
    {
        _taskService = taskService;
    }

    public async Task<TaskResponse?> CreateTaskAsync(string title, Guid createdByUserId, CancellationToken cancellationToken)
    {
        var task = await _taskService.CreateTaskAsync(title, createdByUserId, cancellationToken);
        if (task == null)
        {
            return null;
        }
        return new TaskResponse(task.Id, task.Title, task.CreatedByUserId, task.CreatedUtc);
    }
}
