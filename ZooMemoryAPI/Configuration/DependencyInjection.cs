using Carter;
using MongoDB.Driver;
using ZooMemoryAPI.Domain.Entity;
using ZooMemoryAPI.Mapper;
using ZooMemoryAPI.Repository;
using ZooMemoryAPI.Service;
using ZooMemoryAPI.Service.Implementations;

namespace ZooMemoryAPI.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        return services
            .AddEndpointsApiExplorer()
            .AddSwaggerGen()
            .AddCarter()
            .AddTransient<AnimalMapper>()
            .AddSingleton<IAnimalRepository, AnimalRepository>()
            .AddSingleton<IAnimalService, AnimalService>()
            .AddSingleton(_ =>
            {
                var conn = configuration["DatabaseSettings:ConnectionString"] ?? "mongodb://localhost:27017";
                var database = configuration["DatabaseSettings:DatabaseName"] ?? "zoo";
                var config = MongoClientSettings.FromConnectionString(conn);
                var mongoClient = new MongoClient(config);
                var mongoDatabase = mongoClient.GetDatabase(database);
                return mongoDatabase.GetCollection<AnimalEntity>("animals");
            })
            .AddSingleton<IAnimalRepository, AnimalRepository>();
    }
}