using jobList.Application.Interfaces;
using jobList.Domain.Entities;
using jobList.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace jobList.Persistence.Repositories;

public class JobRepository : IJobRepository
{
    private readonly AppDbContext _context;

    public JobRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task AddJobAsync(Job job)
    {
        await _context.Jobs.AddAsync(job);

        await _context.SaveChangesAsync();
    }

    public async Task<List<Job>> GetAllJobsAsync()
    {
        return await _context.Jobs.ToListAsync();
    }

    public async Task<Job?> GetJobByIdAsync(Guid id)
    {
        return await _context.Jobs.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateJobAsync(Job job)
    {
        _context.Jobs.Update(job);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteJobAsync(Job job)
    {
        _context.Jobs.Remove(job);

        await _context.SaveChangesAsync();
    }

    public async Task<List<Job>> SearchJobAsync(string title)
    {
        return await _context.Jobs
            .Where(x => x.Title.Contains(title))
            .ToListAsync();
    }
}