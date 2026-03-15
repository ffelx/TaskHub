using Api.Services.Interfaces;

namespace Api.Services
{
    public class DisposedService : IDisposable, IHasInstanceId
    {
        private bool _disposed;
        public Guid InstanceId { get; } = Guid.NewGuid();

        public DisposedService()
        {
            Console.WriteLine($"Create: {GetType().Name} - {InstanceId}");
        }

        public void Dispose()
        {
            if (_disposed) return;
            _disposed = true;
            Console.WriteLine($"Dispose: {GetType().Name} - {InstanceId}");

        }
    }
}
