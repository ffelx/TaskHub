using Api.UseCases.Tasks.Interfaces;
using Dal.Entities;
using Logic.Tasks.Services.Interfaces;
using Logic.Users.Services.Interfaces;

namespace Api.UseCases.Tasks
{
    public class DeleteTaskUseCase : IDeleteTaskUseCase
    {
        private readonly ITaskService _taskService;
        public DeleteTaskUseCase(ITaskService userService)
        {
            _taskService = userService;
        }

        public async Task<bool> DeleteTaskByIdAsync(Guid taskId, CancellationToken cancellationToken)
        {
            return await _taskService.DeleteTaskByIdAsync(taskId, cancellationToken);
        }
    }
}
