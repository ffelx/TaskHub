using Api.Extensions;
using Api.Services;
using Api.Services.Interfaces;
using LoggingLibrary;
using Microsoft.Extensions.DependencyInjection;

namespace Api;

/// <summary>
/// Точка входа приложения
/// </summary>
public sealed class Program
{
    /// <summary>
    /// Запуск приложения
    /// </summary>
    public static void Main(string[] args)
    {
        using var host = Host.CreateDefaultBuilder(args)
            .UseInfraSerilog()
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            })
            .Build();
        TestLifetime(host);
        host.Run();
    }

    private static void TestLifetime(IHost host)
    {
        Console.WriteLine("First Scope");
        using (var scope = host.Services.CreateScope())
        {
            ResolveAll(scope.ServiceProvider);
        }
        Console.WriteLine("End First Scope\n");
        
        Console.WriteLine("Second Scope");
        using (var scope = host.Services.CreateScope())
        {
            ResolveAll(scope.ServiceProvider);
        }
        Console.WriteLine("End Second Scope\n");
    }

    private static void ResolveAll(IServiceProvider provider)
    {
        provider.ResolveServices<ITransientService1>();
        provider.ResolveServices<ITransientService2>();
        provider.ResolveServices<IScopedService1>();
        provider.ResolveServices<IScopedService2>();
        provider.ResolveServices<ISingletonService1>();
        provider.ResolveServices<ISingletonService2>();
    }
}