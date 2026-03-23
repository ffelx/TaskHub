namespace Api.UseCases.Tasks.Interfaces
{
    public interface ISetTaskTitleUseCase
    {
        Task<bool> SetTaskTitleAsync(Guid taskId, string title, CancellationToken cancellationToken);
    }
}
