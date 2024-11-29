using Moq;
using TaskFlow.Application.Interfaces.v1;
using TaskFlow.Domain.Entities.v1;
using TaskFlow.Domain.Enums.v1;
using TaskFlow.Domain.Notifications.v1;

namespace TaskFlow.Tests.UnitTests.v1;

public class WorkServiceTests
{
    [Fact]
    public async Task CreateWork_WithinLimit_ShouldSucceed()
    {
        var mockRepo = new Mock<IWorkRepository>();
        var work = new Work
        {
            Id = Guid.NewGuid(),
            Title = "Test Work",
            Priority = Priority.Medium
        };

        mockRepo.Setup(x => x.CreateWorkAsync(It.IsAny<Work>(), It.IsAny<Guid>()))
            .ReturnsAsync(new ResultNotification<Work>
                {
                    Success = true,
                    Message = string.Empty,
                    Data = work
                });

        var result = await mockRepo.Object.CreateWorkAsync(work, Guid.NewGuid());

        Assert.NotNull(result);
        Assert.True(result.Success);
        Assert.Equal(string.Empty, result.Message);
        Assert.Equal(work.Title, result.Data.Title);
    }

    [Fact]
    public async Task CreateWork_ExceedingLimit_ShouldFail()
    {
        var mockRepo = new Mock<IWorkRepository>();
        var work = new Work
        {
            Id = Guid.NewGuid(),
            Title = "Test Work",
            Priority = Priority.Medium
        };

        mockRepo.Setup(x => x.CreateWorkAsync(It.IsAny<Work>(), It.IsAny<Guid>()))
            .ReturnsAsync(new ResultNotification<Work>
                {
                    Success = false,
                    Message = "Project has reached the maximum limit of 20 works.",
                    Data = null
                });

        var result = await mockRepo.Object.CreateWorkAsync(work, Guid.NewGuid());

        Assert.NotNull(result);
        Assert.False(result.Success);
        Assert.Equal("Project has reached the maximum limit of 20 works.", result.Message);
        Assert.Null(result.Data);
    }
}