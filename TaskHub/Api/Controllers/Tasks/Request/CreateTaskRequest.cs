namespace Api.Controllers.Tasks.Request
{
    public class CreateTaskRequest
    {
        public required string Title { get; init; }
        public required Guid CreatedByUserId { get; init; }
    }
}
