using jobList.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace jobList.Persistence.Context;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {

    }

    public DbSet<Job> Jobs { get; set; }
}