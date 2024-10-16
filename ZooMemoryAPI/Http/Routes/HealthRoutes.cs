using Carter;

namespace ZooMemoryAPI.Http.Routes;

public class HealthRoutes() : CarterModule("/health")
{
    public override void AddRoutes(IEndpointRouteBuilder builder)
    {
        builder
            .MapGet("/{name}", async (String name) => 
                await Task.Run(() => $"Hello from service, {name}"));
    }
    
}