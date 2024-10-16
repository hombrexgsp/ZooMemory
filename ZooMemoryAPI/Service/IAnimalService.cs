using ZooMemoryAPI.Domain.Animal;

namespace ZooMemoryAPI.Service;

public interface IAnimalService
{
    Task<IEnumerable<Animal>> GetAnimalsAsync();
    Task<Animal> GetAnimalAsync(Guid id);
    Task<Animal> AddAnimalAsync(CreateAnimal createAnimal);
    Task<Boolean> DeleteAnimalAsync(Guid id);
}