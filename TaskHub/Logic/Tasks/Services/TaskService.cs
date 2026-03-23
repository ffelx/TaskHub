using Dal.Entities;
using Dal.Repositories;
using Dal.Repositories.Interfaces;
using Logic.Tasks.Models;
using Logic.Tasks.Services.Interfaces;
using Logic.Users.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Logic.Tasks.Services;

internal class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;
    private readonly IUserRepository _userRepository;


    public TaskService(
        ITaskRepository taskRepository, 
        IUserRepository userRepository)
    {
        _taskRepository = taskRepository;
        _userRepository = userRepository;
    }

    public async Task<TaskModel?> CreateTaskAsync(string title, Guid createdByUserId, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByIdAsync(createdByUserId, cancellationToken);
        if (user == null)
        {
            return null;
        }

        var task = await _taskRepository.CreateTaskAsync(
           title,
           DateTimeOffset.UtcNow,
           createdByUserId,
           cancellationToken);
        return new TaskModel(task.Id, task.Title, task.CreatedByUserId, task.CreatedUtc);
    }

    

    public async Task<IReadOnlyCollection<TaskModel>> GetAllTasksAsync(CancellationToken cancellationToken)
    {
        var tasks = await _taskRepository.GetTasksAsync(cancellationToken);

        var result = tasks
            .Select(x => new TaskModel(x.Id, x.Title, x.CreatedByUserId, x.CreatedUtc))
            .ToList()
            .AsReadOnly();

        return result;
    }

    public async Task<TaskModel?> GetTaskByIdAsync(Guid taskId, CancellationToken cancellationToken)
    {
        var task = await _taskRepository.GetTaskByIdAsync(taskId, cancellationToken);

        if (task == null)
        {
            return null;
        }

        return new TaskModel(task.Id, task.Title, task.CreatedByUserId, task.CreatedUtc);
    }

    public async Task<bool> SetTaskTitleAsync(Guid taskId, string title, CancellationToken cancellationToken)
    {
        return await _taskRepository.SetTaskTitleAsync(taskId, title, cancellationToken);
    }

    public async Task<bool> DeleteTaskByIdAsync(Guid taskId, CancellationToken cancellationToken)
    {
        return await _taskRepository.DeleteTaskByIdAsync(taskId, cancellationToken);
    }

    public async Task DeleteAllTasksAsync(CancellationToken cancellationToken)
    {
        await _taskRepository.DeleteAllTasksAsync(cancellationToken);
    }
}
