namespace TaskFlow.Domain.Entities.v1;

public class WorkComment
{
    public string Id { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}