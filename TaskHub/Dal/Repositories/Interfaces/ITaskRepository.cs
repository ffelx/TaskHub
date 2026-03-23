using Dal.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Repositories.Interfaces;

public interface ITaskRepository
{
    Task<TaskEntity> CreateTaskAsync(
        string title, 
        DateTimeOffset createdUtc,
        Guid createdByUserId,
        CancellationToken cancellationToken);

    Task<IReadOnlyCollection<TaskEntity>> GetTasksAsync(CancellationToken cancellationToken);

    Task<TaskEntity?> GetTaskByIdAsync(Guid taskId, CancellationToken cancellationToken);

    Task<bool> SetTaskTitleAsync(Guid taskId, string title, CancellationToken cancellationToken);

    Task<bool> DeleteTaskByIdAsync(Guid taskId, CancellationToken cancellationToken);

    Task DeleteAllTasksAsync(CancellationToken cancellationToken);
}
