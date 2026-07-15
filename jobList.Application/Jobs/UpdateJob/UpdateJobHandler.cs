using jobList.Application.Interfaces;

namespace jobList.Application.Jobs.UpdateJob;

public class UpdateJobHandler
{
    private readonly IJobRepository _jobRepository;

    public UpdateJobHandler(IJobRepository jobRepository)
    {
        _jobRepository = jobRepository;
    }

    public async Task<bool> Handle(UpdateJobCommand command)
    {
        var job = await _jobRepository.GetJobByIdAsync(command.Id);

        if (job == null)
        {
            return false;
        }

        job.Title = command.Title;
        job.Description = command.Description;
        job.Salary = command.Salary;
        job.WorkingMode = command.WorkingMode;
        job.UpdatedAt = DateTime.Now;

        await _jobRepository.UpdateJobAsync(job);

        return true;
    }
}