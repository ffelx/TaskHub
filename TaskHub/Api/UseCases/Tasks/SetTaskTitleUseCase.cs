using Api.UseCases.Tasks.Interfaces;
using Dal.Entities;
using Logic.Tasks.Services.Interfaces;
using Logic.Users.Services.Interfaces;
using System.Xml.Linq;

namespace Api.UseCases.Tasks
{
    public class SetTaskTitleUseCase : ISetTaskTitleUseCase
    {
        private readonly ITaskService _taskService;

        public SetTaskTitleUseCase(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public async Task<bool> SetTaskTitleAsync(Guid taskId, string title, CancellationToken cancellationToken)
        {
            return await _taskService.SetTaskTitleAsync(taskId, title, cancellationToken);
        }
    }
}
