using jobList.Application.Interfaces;
using jobList.Domain.Entities;
using jobList.Application.Jobs.DTOs;

namespace jobList.Application.Jobs.SearchJobs;

public class SearchJobHandler
{
    private readonly IJobRepository _jobRepository;

    public SearchJobHandler(IJobRepository jobRepository)
    {
        _jobRepository = jobRepository;
    }

    public async Task<List<JobDto>>Handle(SearchJobQuery query)
    {
        var jobs = await _jobRepository.SearchJobAsync(query);

        return jobs.Select(x => new JobDto
        {
            Id = x.Id,
            Title = x.Title,
            Salary = x.Salary,
            WorkingMode = x.WorkingMode,
            CompanyName = ""
        }).ToList();
    }
}