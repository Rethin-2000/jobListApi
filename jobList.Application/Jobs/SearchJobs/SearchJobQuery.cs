using jobList.Domain.Enums;

namespace jobList.Application.Jobs.SearchJobs
{
    public class SearchJobQuery
    {
        public string? Title { get; set; }

        public int Page {get; set; } = 1;

        public int PageSize { get; set; } = 10;

        public WorkingMode? WorkingMode { get; set; }

        public string? SortBy { get; set; }

        public bool Descending { get; set; }
    }
}