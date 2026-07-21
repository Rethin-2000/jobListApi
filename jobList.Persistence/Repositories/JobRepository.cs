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
       var jobs = _context.Jobs.AsQueryable();

        if (!string.IsNullOrWhiteSpace(query.Title))
        {
           
                jobs = jobs.Where(x => x.Title.Contains(query.Title));
            
        }

        if (query.WorkingMode.HasValue)
        {
            jobs = jobs.Where(x => x.WorkingMode == query.WorkingMode.Value);
        }

        if(query.SortBy == "salary")
        {
            jobs = query.Descending
                ? jobs.OrderByDescending(x => x.Salary)
                : jobs.OrderBy(x => x.Salary);
        }else if (query.SortBy == "title")
        {
            jobs = query.Descending
                ? jobs.OrderByDescending(x => x.Title)
                : jobs.OrderBy(x => x.Title);
        }

        return await jobs
            .Skip((query.Page -1) * query.PageSize)
            .Take(query.PageSize)
            .ToListAsync();
    }
}