using jobList.Application.Interfaces;
using jobList.Application.Jobs.DTOs;

namespace jobList.Application.Jobs.GetJobById;

public class GetJobByIdHandler
{
    private readonly IJobRepository _jobRepository;

    public GetJobByIdHandler(IJobRepository jobRepository)
    {
        _jobRepository = jobRepository;
    }

    public async Task<JobDto?> Handle(GetJobByIdQuery query)
    {
        var job = await _jobRepository.GetJobByIdAsync(query.Id);

        if (job == null)
        {
            return null;
        }

        return new JobDto
        {
            Id = job.Id,
            Title = job.Title,
            Salary = job.Salary,
            WorkingMode = job.WorkingMode,
            CompanyName = ""
        };
    }
}