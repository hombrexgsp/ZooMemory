using ZooMemoryAPI.Domain.Animal;
using ZooMemoryAPI.Mapper;
using ZooMemoryAPI.Repository;

using ZooMemoryAPI.Domain.Entity;
using ZooMemoryAPI.Domain.Error;

namespace ZooMemoryAPI.Service.Implementations;

public class AnimalService(
    IAnimalRepository animalRepository,
    AnimalMapper mapper) : IAnimalService
{
    public async Task<IEnumerable<Animal>> GetAnimalsAsync()
    {
        var animalList = await animalRepository.GetAllAsync();
        return animalList.Select(mapper.FromEntity);
    }

    public async Task<Animal> GetAnimalAsync(Guid uuid) =>
        await animalRepository.GetAsync(uuid)
            .Bind(animal =>
                animal is null
                    ? TaskFail<AnimalEntity>(new AnimalNotFound(uuid))
                    : TaskSucc(animal))
            .Select(mapper.FromEntity);

    public async Task<Animal> AddAnimalAsync(CreateAnimal createAnimal) =>
        await animalRepository .CreateAsync(mapper.FromDto(createAnimal.ToAnimal()))
            .Select(mapper.FromEntity);

    public async Task<Boolean> DeleteAnimalAsync(Guid uuid) =>
        await animalRepository.GetAsync(uuid)
            .Bind(animal =>
                animal is null
                    ? TaskFail<Boolean>(new AnimalNotFound(uuid))
                    : animalRepository.DeleteAsync(uuid));
}