using FizzBuzz;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

//Use of DI to be abble to use both the minimal program style and unit test

var builder = Host.CreateDefaultBuilder(args);

// Register services with DI container
builder.ConfigureServices((context, services) =>
{    
    services.AddSingleton<IApplicationService, ApplicationService>();
});

var host = builder.Build();

// Resolve and use the application service
var appService = host.Services.GetRequiredService<IApplicationService>();
appService.Run(args);

await host.RunAsync();

return 0;