using jobList.Application.Interfaces;

namespace jobList.Application.Jobs.DeleteJob;

public class DeleteJobHandler
{
    private readonly IJobRepository _jobRepository;

    public DeleteJobHandler(IJobRepository jobRepository)
    {
        _jobRepository = jobRepository;
    }

    public async Task<bool> Handle(DeleteJobCommand command)
    {
        var job = await _jobRepository.GetJobByIdAsync(command.Id);

        if (job == null)
        {
            return false;
        }

        await _jobRepository.DeleteJobAsync(job);

        return true;
    }
}