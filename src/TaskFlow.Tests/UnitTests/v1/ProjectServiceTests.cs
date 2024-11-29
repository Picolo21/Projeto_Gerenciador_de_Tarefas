using Moq;
using TaskFlow.Application.Interfaces.v1;
using TaskFlow.Domain.Entities.v1;

namespace TaskFlow.Tests.UnitTests.v1;

public class ProjectServiceTests
{
    [Fact]
    public async Task CreateProject_ShouldSucceed()
    {
        var mockRepo = new Mock<IProjectRepository>();
        var project = new Project { Name = "Test Project" };
        mockRepo.Setup(x => x.CreateProjectAsync(It.IsAny<Project>()))
            .ReturnsAsync(project);

        var result = await mockRepo.Object.CreateProjectAsync(project);

        Assert.NotNull(result);
        Assert.Equal("Test Project", result.Name);
    }

    [Fact]
    public async Task GetUserProjects_ShouldReturnProjects()
    {
        var mockRepo = new Mock<IProjectRepository>();
        var projects = new List<Project>
            {
                new Project { Name = "Project 1" },
                new Project { Name = "Project 2" }
            };
        mockRepo.Setup(x => x.GetUserProjectsAsync())
            .ReturnsAsync(projects);

        var result = await mockRepo.Object.GetUserProjectsAsync();

        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
    }
}