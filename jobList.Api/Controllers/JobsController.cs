using jobList.Application.Jobs.CreateJob;
using jobList.Application.Jobs.GetJobById;
using jobList.Application.Jobs.DeleteJob;
using jobList.Application.Jobs.UpdateJob;
using jobList.Application.Jobs.SearchJobs;
using Microsoft.AspNetCore.Mvc;


namespace jobList.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class JobsController : ControllerBase
{
    private readonly CreateJobHandler _createJobhandler;
    private readonly GetJobByIdHandler _getJobByIdHandler;
    private readonly DeleteJobHandler _deleteJobHandler;
    private readonly UpdateJobHandler _updateJobHandler;
    private readonly SearchJobHandler _searchJobHandler;
    public JobsController(CreateJobHandler handler,  GetJobByIdHandler getJobByIdHandler, DeleteJobHandler deleteJobHandler, UpdateJobHandler updateJobHandler, SearchJobHandler searchJobHandler)
    {
        _createJobhandler = handler;
        _getJobByIdHandler = getJobByIdHandler;
        _deleteJobHandler = deleteJobHandler;
        _updateJobHandler = updateJobHandler;
        _searchJobHandler = searchJobHandler;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateJobCommand command)
    {
        await _createJobhandler.Handle(command);
        return Ok("Job created successfully");
    }
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] SearchJobQuery query)
    {
        var jobs = await _searchJobHandler.Handle(query);

        return Ok(jobs);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var job = await _getJobByIdHandler.Handle(
            new GetJobByIdQuery
            {
                Id = id
            });

        if (job == null)
        {
            return NotFound();
        }

        return Ok(job);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _deleteJobHandler.Handle(
            new DeleteJobCommand
            {
                Id = id
            });

        if (!result)
        {
            return NotFound();
        }

        return Ok("Job deleted successfully");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdateJobCommand command)
    {
        command.Id = id;

        var result = await _updateJobHandler.Handle(command);

        if (!result)
        {
            return NotFound("Job not found");
        }

        return Ok("Job updated successfully");
    }



}