using Logic.Tasks.Models;
using Logic.Users.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Tasks.Services.Interfaces;

public interface ITaskService
{
     Task<TaskModel?> CreateTaskAsync(
        string title, 
        Guid createdByUserId,
        CancellationToken cancellationToken);

    Task<IReadOnlyCollection<TaskModel>> GetAllTasksAsync(CancellationToken cancellationToken);

    Task<TaskModel?> GetTaskByIdAsync(Guid taskId, CancellationToken cancellationToken);

    Task<bool> SetTaskTitleAsync(Guid taskId, string title, CancellationToken cancellationToken);

    Task<bool> DeleteTaskByIdAsync(Guid taskId, CancellationToken cancellationToken);

    Task DeleteAllTasksAsync(CancellationToken cancellationToken);
}
