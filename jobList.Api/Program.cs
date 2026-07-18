using jobList.Application.Interfaces;
using jobList.Persistence.Repositories;
using jobList.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using jobList.Application.Jobs.CreateJob;
using jobList.Application.Jobs.GetJobById;
using jobList.Application.Jobs.UpdateJob;
using jobList.Application.Jobs.DeleteJob;
using jobList.Application.Jobs.SearchJobs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddScoped<IJobRepository, JobRepository>();
builder.Services.AddScoped<CreateJobHandler>();
builder.Services.AddScoped<GetJobByIdHandler>();
builder.Services.AddScoped<UpdateJobHandler>();
builder.Services.AddScoped<DeleteJobHandler>();
builder.Services.AddScoped<SearchJobHandler>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"))); 



var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//app.UseHttpsRedirection();



app.MapControllers();
app.Run();


