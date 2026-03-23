using Api.Controllers.Tasks.Response;
using Api.Controllers.Users.Response;
using System.Collections.ObjectModel;

namespace Api.UseCases.Tasks.Interfaces
{
    public interface IGetTasksUseCase
    {
        Task<ReadOnlyCollection<TaskResponse>> GetAllTasksAsync(CancellationToken cancellationToken);
    }
}
