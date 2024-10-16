using Riok.Mapperly.Abstractions;
using ZooMemoryAPI.Domain.Animal;
using ZooMemoryAPI.Domain.Entity;

namespace ZooMemoryAPI.Mapper;

[Mapper]
public partial class AnimalMapper
{
    [MapperIgnoreTarget(nameof(AnimalEntity.Id))]
    public partial AnimalEntity FromDto(Animal animal);
    
    [MapperIgnoreSource(nameof(AnimalEntity.Id))]
    public partial Animal FromEntity(AnimalEntity entity);
}