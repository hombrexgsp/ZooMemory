namespace ZooMemoryAPI.Domain.Error;

public class AnimalAlreadyExists(Guid uuid) : Exception($"Animal with id {uuid} already exists");
    