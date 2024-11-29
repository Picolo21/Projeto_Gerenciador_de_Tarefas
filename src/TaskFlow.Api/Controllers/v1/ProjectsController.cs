using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.Dtos.v1;
using TaskFlow.Application.Interfaces.v1;
using TaskFlow.Domain.Entities.v1;

namespace TaskFlow.Api.Controllers.v1;

[Route("api/v1/[controller]")]
[ApiController]
public class ProjectsController : ControllerBase
{
    private readonly IProjectRepository _projectRepository;
    private readonly IMapper _mapper;

    public ProjectsController(IProjectRepository projectRepository, IMapper mapper)
    {
        _projectRepository = projectRepository;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProjectsAsync()
    {
        var projects = await _projectRepository.GetUserProjectsAsync();
        return Ok(projects);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<Project> CreateProjectAsync([FromBody] ProjectDto projectDto)
    {
        var projectEntity = _mapper.Map<Project>(projectDto);
        var createdProject = await _projectRepository.CreateProjectAsync(projectEntity);
        return createdProject;
    }
}