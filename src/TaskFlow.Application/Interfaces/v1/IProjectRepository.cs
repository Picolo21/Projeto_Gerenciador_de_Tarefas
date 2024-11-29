using TaskFlow.Domain.Entities.v1;

namespace TaskFlow.Application.Interfaces.v1;

public interface IProjectRepository
{
    Task<Project> CreateProjectAsync(Project project);
    Task<List<Project>> GetUserProjectsAsync();
}
