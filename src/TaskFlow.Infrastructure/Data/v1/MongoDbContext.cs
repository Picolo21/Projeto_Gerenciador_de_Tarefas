using MongoDB.Driver;
using TaskFlow.Domain.Entities.v1;

namespace TaskFlow.Infrastructure.Data.v1;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(string connectionString, string databaseName)
    {
        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
    }

    public IMongoCollection<Project> Projects =>
        _database.GetCollection<Project>("projects");

    public IMongoCollection<Work> Works =>
        _database.GetCollection<Work>("works");
}