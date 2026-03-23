using Api.Controllers.Tasks.Response;
using Api.Controllers.Users.Response;
using Api.UseCases.Tasks.Interfaces;
using Dal.Entities;
using Logic.Tasks.Services.Interfaces;
using Logic.Users.Services.Interfaces;

namespace Api.UseCases.Tasks;

public class GetTaskUseCase : IGetTaskUseCase
{
    private readonly ITaskService _taskService;

    public GetTaskUseCase(ITaskService taskService)
    {
        _taskService = taskService;
    }

    public async Task<TaskResponse?> GetTaskByIdAsync(Guid taskId, CancellationToken cancellationToken)
    {
        var task = await _taskService.GetTaskByIdAsync(taskId, cancellationToken);

        if (task == null)
        {
            return null;
        }

        return new TaskResponse(task.Id, task.Title, task.CreatedByUserId, task.CreatedUtc);
    }
}
