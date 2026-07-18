using jobList.Domain.Entities;
using jobList.Application.Jobs.SearchJobs;

namespace jobList.Application.Interfaces;

public interface IJobRepository
{
    Task AddJobAsync(Job job);

    

    Task<Job?> GetJobByIdAsync(Guid id);

    Task UpdateJobAsync(Job job);

    Task DeleteJobAsync(Job job);

    Task<List<Job>> SearchJobAsync(SearchJobQuery query);
    
}