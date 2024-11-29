using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using TaskFlow.Domain.Entities.v1;
using TaskFlow.Domain.Enums.v1;
using TaskFlow.Domain.ValueObjects.v1;
using System.Text.Json.Serialization;

namespace TaskFlow.Application.Dtos.v1;

public class WorkDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public Status Status { get; set; }
    public Priority Priority { get; set; }
    public List<WorkComment> Comments { get; set; } = new List<WorkComment>();

    [JsonIgnore]
    public List<AuditLog> AuditHistory { get; set; } = new List<AuditLog>();
}