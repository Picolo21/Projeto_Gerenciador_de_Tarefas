using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using TaskFlow.Domain.Enums.v1;
using TaskFlow.Domain.ValueObjects.v1;

namespace TaskFlow.Domain.Entities.v1;

public class Work
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; }

    [BsonRepresentation(BsonType.String)]
    public Guid ProjectId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public Status Status { get; set; }
    public Priority Priority { get; set; }
    public List<WorkComment> Comments { get; set; }
    public List<AuditLog> AuditHistory { get; set; }
}