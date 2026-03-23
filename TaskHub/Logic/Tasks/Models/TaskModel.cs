using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Tasks.Models;

public class TaskModel
{

    public Guid Id { get; }
    public string? Title { get; }
    public Guid CreatedByUserId { get; }
    public DateTimeOffset CreatedUtc { get; }
    public TaskModel(Guid id, string? title, Guid createdByUserId, DateTimeOffset createdUtc)
    {
        Id = id;
        Title = title;
        CreatedByUserId = createdByUserId;
        CreatedUtc = createdUtc;
    }
}
