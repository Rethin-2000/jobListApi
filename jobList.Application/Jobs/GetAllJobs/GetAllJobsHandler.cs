using jobList.Application.Interfaces;
using jobList.Application.Jobs.DTOs;


namespace jobList.Application.Jobs.GetAllJobs;

public class GetAllJobsHandler
{
    private readonly IJobRepository _jobRepository;

    public GetAllJobsHandler(IJobRepository jobRepository)
    {
        _jobRepository = jobRepository;
    }

    public async Task<List<JobDto>> Handle(GetAllJobsQuery query)
    {
        var jobs = await _jobRepository.GetAllJobsAsync();

        var result =  new List<JobDto>();

        foreach (var job in jobs)
        {
            
                result.Add(new JobDto
                {
                    Id = job.Id,
                    Title = job.Title,
                    Salary = job.Salary,
                    WorkingMode = job.WorkingMode,

                    CompanyName = ""
                });
            
    }

    return  result;
    }
}