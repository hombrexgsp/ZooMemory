# ZooMemory

Just a simple service for storing crucial information about animals in the zoo 🦁.

## Using the API

Be sure to have MongoDB installed and running on your machine, we are using the default Docker image for MongoDB: 

```bash
docker run --name zoo-memory-db -d mongo:latest --port 27017:27017
```

Then you can run the application using the latest .NET Core SDK:

```bash
dotnet run --project ZooMemoryAPI/ZooMemoryAPI.csproj
```

## Endpoints
Although the project uses Swagger for documentation, here are some of the main endpoints:

| Method   | Endpoint        | Description                                                       |
|:---------|:----------------|:------------------------------------------------------------------|
| `GET`    | `/animals`      | Get all animals                                                   |
| `GET`    | `/animals/{id}` | Get an animal by GUID                                             |
| `POST`   | `/animals`      | Create a new animal (see the schema in the Swagger documentation) |
| `DELETE` | `/animals/{id}` | Delete an animal by GUID                                          |
