using jobList.Domain.Enums;

namespace jobList.Application.Jobs.UpdateJob;

public class UpdateJobCommand
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public decimal Salary { get; set; }

    public WorkingMode WorkingMode { get; set; }
}