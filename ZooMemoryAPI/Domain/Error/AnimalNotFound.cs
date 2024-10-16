namespace ZooMemoryAPI.Domain.Error;

public class AnimalNotFound(Guid uuid) : Exception($"Animal with id {uuid} not found");