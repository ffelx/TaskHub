using Api.Controllers.Tasks.Response;
using Api.Controllers.Users.Response;

namespace Api.UseCases.Tasks.Interfaces;

public interface ICreateTaskUseCase
{
    Task<TaskResponse?> CreateTaskAsync(string title, Guid createdByUserId, CancellationToken cancellationToken);
}
