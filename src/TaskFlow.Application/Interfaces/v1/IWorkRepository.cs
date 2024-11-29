using MongoDB.Bson;
using TaskFlow.Domain.Entities.v1;
using TaskFlow.Domain.Notifications.v1;

namespace TaskFlow.Application.Interfaces.v1;

public interface IWorkRepository
{
    Task<ResultNotification<Work>> CreateWorkAsync(Work work, Guid projectId);
    Task<List<Work>> GetProjectWorksAsync(Guid projectId);
    Task DeleteWorkAsync(Guid id, Guid projectId);
}
