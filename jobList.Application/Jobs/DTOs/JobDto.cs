using jobList.Domain.Enums;

namespace jobList.Application.Jobs.DTOs;

public class JobDto
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public decimal Salary { get; set; }

    public WorkingMode WorkingMode { get; set; }

    public string CompanyName { get; set; } = string.Empty;
}