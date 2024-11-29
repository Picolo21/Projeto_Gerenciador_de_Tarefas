using MongoDB.Driver;
using TaskFlow.Application.Interfaces.v1;
using TaskFlow.Domain.Entities.v1;
using TaskFlow.Infrastructure.Data.v1;

namespace TaskFlow.Infrastructure.Repositories.v1;

public class ProjectRepository : IProjectRepository
{
    public ProjectRepository(MongoDbContext context)
    {
        _context = context;
    }

    private readonly MongoDbContext _context;

    public async Task<Project> CreateProjectAsync(Project project)
    {
        project.Id = Guid.NewGuid();
        await _context.Projects.InsertOneAsync(project);
        return project;
    }

    public async Task<List<Project>> GetUserProjectsAsync() => 
        await _context.Projects.Find(_ => true).ToListAsync();
}