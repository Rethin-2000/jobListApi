using jobList.Domain.Enums;

namespace jobList.Domain.Entities;

public class Job : BaseEntity
{
    

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
     
    public decimal Salary { get; set; }

    public Guid CompanyId { get; set; }

    public WorkingMode WorkingMode { get; set; }

    //public Company Company { get; set; }
}