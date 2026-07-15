using jobList.Application.Interfaces;
using jobList.Domain.Entities;

namespace jobList.Application.Jobs.SearchJobs;

public class SearchJobHandler
{
    private readonly IJobRepository _jobRepository;

    public SearchJobHandler(IJobRepository jobRepository)
    {
        _jobRepository = jobRepository;
    }

    public async Task<List<Job>>Handle(SearchJobQuery query)
    {
        if(string.IsNullOrWhiteSpace(query.Title))
        {
            return await _jobRepository.GetAllJobsAsync();
        }

        return await _jobRepository.SearchJobAsync(query.Title);
    }
}