using jobList.Domain.Entities;

namespace jobList.Application.Interfaces;

public interface IJobRepository
{
    Task AddJobAsync(Job job);

    Task<List<Job>> GetAllJobsAsync();

    Task<Job?> GetJobByIdAsync(Guid id);

    Task UpdateJobAsync(Job job);

    Task DeleteJobAsync(Job job);

    Task<List<Job>> SearchJobAsync(string Title);
    
}