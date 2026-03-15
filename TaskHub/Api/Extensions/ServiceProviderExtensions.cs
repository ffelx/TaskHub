using Api.Services.Interfaces;

namespace Api.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static void ResolveServices<TService>(this IServiceProvider serviceProvider) where TService : class, IHasInstanceId
        {
            var first = serviceProvider.GetRequiredService<TService>();
            var second = serviceProvider.GetRequiredService<TService>();
            Console.WriteLine(
            $"Type: {typeof(TService).Name} " +
            $"| first = {first.InstanceId} " +
            $"| second = {second.InstanceId} " +
            $"| isSame = {ReferenceEquals(first, second)}");
        }
    }
}
