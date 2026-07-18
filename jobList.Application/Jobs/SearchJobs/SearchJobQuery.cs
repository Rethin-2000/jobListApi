namespace jobList.Application.Jobs.SearchJobs
{
    public class SearchJobQuery
    {
        public string? Title { get; set; }

        public int Page {get; set; } = 1;

        public int PageSize { get; set; } = 10;
    }
}