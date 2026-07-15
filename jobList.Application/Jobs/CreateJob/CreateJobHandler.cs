
using jobList.Application.Interfaces;
using jobList.Domain.Entities;

namespace jobList.Application.Jobs.CreateJob;

public class CreateJobHandler
{
    private readonly IJobRepository _jobRepository;

    public CreateJobHandler(IJobRepository jobRepository)
    {
        _jobRepository = jobRepository;
    }

    public async Task Handle(CreateJobCommand command)
    {
        var job = new Job
        {
            Id = Guid.NewGuid(),

            Title = command.Title,
            Description = command.Description,
            Salary = command.Salary,
            CompanyId = command.CompanyId,
            WorkingMode = command.WorkingMode,

            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };

        await _jobRepository.AddJobAsync(job);
    }
}