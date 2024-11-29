namespace TaskFlow.Domain.Notifications.v1;

public class ResultNotification<T>
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }
}
