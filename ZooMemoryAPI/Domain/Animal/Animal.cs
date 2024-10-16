using System.ComponentModel.DataAnnotations;
using ZooMemoryAPI.Domain.Conservation;

namespace ZooMemoryAPI.Domain.Animal;

public record Animal(
    [Required]
    Guid Uuid,
    
    [Required]
    String Name, 
    
    [Required]
    ConservationStatus Conservation,
    
    [Range(0, Int32.MaxValue)]
    Int32 Population);