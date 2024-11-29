using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TaskFlow.Domain.Entities.v1;

public class Project
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; }

    public string Name { get; set; }

    [BsonRepresentation(BsonType.String)]
    public List<Guid> WorkIds { get; set; } = new List<Guid>();
    public DateTime CreatedAt { get; set; }
}