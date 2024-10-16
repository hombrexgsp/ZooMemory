using System.ComponentModel.DataAnnotations;
using ZooMemoryAPI.Domain.Conservation;

namespace ZooMemoryAPI.Domain.Animal;

public record CreateAnimal(
    [Required] String Name,

    [Required] ConservationStatus Conservation,

    [Range(0, Int32.MaxValue)] Int32 Population)
{
    public Animal ToAnimal() => 
        new Animal(
            Guid.NewGuid(),
            Name,
            Conservation,
            Population);
}