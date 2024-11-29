using MongoDB.Driver;
using TaskFlow.Application.Interfaces.v1;
using TaskFlow.Domain.Entities.v1;
using TaskFlow.Domain.Notifications.v1;
using TaskFlow.Infrastructure.Data.v1;

namespace TaskFlow.Infrastructure.Repositories.v1;

public class WorkRepository : IWorkRepository
{
    public WorkRepository(MongoDbContext context)
    {
        _context = context;
    }

    private readonly MongoDbContext _context;

    public async Task<ResultNotification<Work>> CreateWorkAsync(Work work, Guid projectId)
    {
        var project = await _context.Projects.Find(project => project.Id == projectId).FirstOrDefaultAsync();

        if (project.WorkIds.Count >= 20)
        {
            return new ResultNotification<Work>
            {
                Success = false,
                Message = "Project has reached the maximum limit of 20 works.",
                Data = null
            };
        }
            

        work.Id = Guid.NewGuid();
        work.ProjectId = project.Id;

        await _context.Works.InsertOneAsync(work);

        project.WorkIds.Add(work.Id);
        await _context.Projects.ReplaceOneAsync(project => project.Id == projectId, project);

        return new ResultNotification<Work>
        {
            Success = true,
            Message = string.Empty,
            Data = work
        };
    }

    public async Task<List<Work>> GetProjectWorksAsync(Guid projectId)
    {
        return await _context.Works
            .Find(work => work.ProjectId == projectId)
        .ToListAsync();
    }

    public async Task DeleteWorkAsync(Guid id, Guid projectId)
    {
        await _context.Works.DeleteOneAsync(work => work.Id == id);

        var filter = Builders<Project>.Filter.Eq(project => project.Id, projectId);
        var update = Builders<Project>.Update.Pull(project => project.WorkIds, id);

        await _context.Projects.UpdateOneAsync(filter, update);


    }
}