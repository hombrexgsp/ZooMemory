using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using Carter;
using Microsoft.AspNetCore.Http.HttpResults;
using ZooMemoryAPI.Domain.Animal;
using ZooMemoryAPI.Service;

namespace ZooMemoryAPI.Http.Routes;

public class AnimalRoutes(IAnimalService animalService) : CarterModule("/animals")
{
    public override void AddRoutes(IEndpointRouteBuilder builder)
    {
        builder.MapGet("/", async () => await animalService.GetAnimalsAsync());

        builder.MapGet("/{id:guid}", async (Guid id) =>
            await animalService.GetAnimalAsync(id)
                .Select(Results.Ok));

        builder.MapPost("/", async (CreateAnimal animal) =>
        {
            var result = await animalService.AddAnimalAsync(animal);

            return Results.Created($"/{result.Uuid}", result);
        });
        
        builder.MapDelete("/{id:guid}", async (Guid id) => await animalService.DeleteAnimalAsync(id)
            ? Results.NoContent()
            : Results.NotFound());
        
    }
}