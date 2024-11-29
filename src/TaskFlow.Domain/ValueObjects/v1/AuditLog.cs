namespace TaskFlow.Domain.ValueObjects.v1;

public class AuditLog
{
    public DateTime ModifiedAt { get; set; }
    public string ModifiedBy { get; set; }
    public string Changes { get; set; }
}
