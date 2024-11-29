using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using TaskFlow.Application.Dtos.v1;
using TaskFlow.Application.Interfaces.v1;
using TaskFlow.Domain.Entities.v1;

namespace TaskFlow.Api.Controllers.v1;

[Route("api/v1/[controller]")]
[ApiController]
public class WorksController : ControllerBase
{
    private readonly IWorkRepository _workRepository;
    private readonly IMapper _mapper;

    public WorksController(IWorkRepository workRepository, IMapper mapper)
    {
        _workRepository = workRepository;
        _mapper = mapper;
    }

    

    [HttpGet("{projectId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProjectWorksAsync(Guid projectId)
    {
        var tasks = await _workRepository.GetProjectWorksAsync(projectId);
        return Ok(tasks);
    }

    [HttpPost("{projectId:guid}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> CreateWorkAsync(Guid projectId, [FromBody] WorkDto workDto)
    {
        var workEntity = _mapper.Map<Work>(workDto);
        var createWork = await _workRepository.CreateWorkAsync(workEntity, projectId);

        if (!createWork.Success)
        {
            return BadRequest(new { createWork.Message });
        }

        return Ok(createWork.Data);
    }

    [HttpDelete("{id:guid}/{projectId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> CreateWorkAsync(Guid id, Guid projectId)
    {
        await _workRepository.DeleteWorkAsync(id, projectId);

        return Ok();
    }
}