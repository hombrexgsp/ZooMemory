using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ZooMemoryAPI.Domain.Conservation;

namespace ZooMemoryAPI.Domain.Entity;

public class AnimalEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; set; }
    
    public Guid Uuid { get; set; }
    
    public required String Name { get; init; }
    
    public ConservationStatus Conservation { get; set; }
    
    public Int32 Population { get; set; }
}
    
   