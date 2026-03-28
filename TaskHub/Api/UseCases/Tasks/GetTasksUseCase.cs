using Api.Controllers.Tasks.Response;
using Api.Controllers.Users.Response;
using Api.UseCases.Tasks.Interfaces;
using Logic.Tasks.Services.Interfaces;
using Logic.Users.Services.Interfaces;
using System.Collections.ObjectModel;

namespace Api.UseCases.Tasks;

public class GetTasksUseCase : IGetTasksUseCase
{
    private readonly ITaskService _taskService;

    public GetTasksUseCase(ITaskService taskService)
    {
        _taskService = taskService;
    }

    public async Task<ReadOnlyCollection<TaskResponse>> GetAllTasksAsync(CancellationToken cancellationToken)
    {
        var tasks = await _taskService.GetAllTasksAsync(cancellationToken);

        var response = tasks
            .Select(x => new TaskResponse( x.Id, x.Title, x.CreatedByUserId, x.CreatedUtc))
            .ToList()
            .AsReadOnly();

        return response;
    }
}
