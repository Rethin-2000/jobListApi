using jobList.Application.Jobs.CreateJob;
using jobList.Application.Jobs.GetAllJobs;
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
    private readonly CreateJobHandler _CreateJobhandler;
    private readonly GetAllJobsHandler _getAllJobsHandler;
    private readonly GetJobByIdHandler _getJobByIdHandler;
    private readonly DeleteJobHandler _deleteJobHandler;
    private readonly UpdateJobHandler _updateJobHandler;
    private readonly SearchJobHandler _searchJobHandler;
    public JobsController(CreateJobHandler handler, GetAllJobsHandler getAllJobsHandler, GetJobByIdHandler getJobByIdHandler, DeleteJobHandler deleteJobHandler, UpdateJobHandler updateJobHandler, SearchJobHandler searchJobHandler)
    {
        _CreateJobhandler = handler;
        _getAllJobsHandler = getAllJobsHandler;
        _getJobByIdHandler = getJobByIdHandler;
        _deleteJobHandler = deleteJobHandler;
        _updateJobHandler = updateJobHandler;
        _searchJobHandler = searchJobHandler;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateJobCommand command)
    {
        await _CreateJobhandler.Handle(command);
        return Ok("Job created successfully");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(string? title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            var job = await _getAllJobsHandler.Handle(new GetAllJobsQuery());

            return Ok(job);
        }

        var jobs = await _searchJobHandler.Handle(
            new SearchJobQuery
            {
                Title = title
            });

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