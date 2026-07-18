using jobList.Application.Interfaces;
using jobList.Domain.Entities;
using jobList.Persistence.Context;
using jobList.Application.Jobs.SearchJobs;
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

    public async Task<List<Job>> SearchJobAsync(SearchJobQuery query)
    {
        return await _context.Jobs
            .Where(x =>
                string.IsNullOrWhiteSpace(query.Title) ||
                x.Title.Contains(query.Title))
            .Skip((query.Page - 1) * query.PageSize)
            .Take(query.PageSize)
            .ToListAsync();
    }
}