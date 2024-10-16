using MongoDB.Driver;
using ZooMemoryAPI.Domain.Animal;
using ZooMemoryAPI.Domain.Entity;
using Optional = MongoDB.Driver.Optional;

namespace ZooMemoryAPI.Repository;

public interface IAnimalRepository
{
    Task<IEnumerable<AnimalEntity>> GetAllAsync();
    Task<AnimalEntity?> GetAsync(Guid uuid);
    Task<AnimalEntity> CreateAsync(AnimalEntity createAnimal);
    Task<Boolean> DeleteAsync(Guid id);
}

public class AnimalRepository(IMongoCollection<AnimalEntity> animalCollection): IAnimalRepository
{
    public async Task<IEnumerable<AnimalEntity>> GetAllAsync() =>
        await animalCollection.Find(_ => true).ToListAsync();

    
    public async Task<AnimalEntity?> GetAsync(Guid uuid) =>
        await animalCollection
            .Find(a => a.Uuid == uuid)
            .SingleOrDefaultAsync();


    public async Task<AnimalEntity> CreateAsync(AnimalEntity createAnimal)
    {
        await animalCollection.InsertOneAsync(createAnimal);
        return await animalCollection
            .Find(a => a.Uuid == createAnimal.Uuid)
            .SingleOrDefaultAsync();
    }

    
    public async Task<Boolean> DeleteAsync(Guid id) =>
        await animalCollection
            .DeleteOneAsync(a => a.Uuid == id)
            .ContinueWith(task => task.Result.DeletedCount == 1);
}