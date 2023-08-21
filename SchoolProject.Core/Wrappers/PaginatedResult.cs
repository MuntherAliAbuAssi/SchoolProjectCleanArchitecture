namespace SchoolProject.Core.Wrappers
{
    public class PaginatedResult<T>
    {
        public List<T> Data { get; set; }
        public PaginatedResult(List<T> data)
        {
            Data = data;
        }
        internal PaginatedResult(bool succeeded, List<T> data = default, List<string> messages = null, int count = 0, int page = 1, int pageSize = 1)
        {
            Data = data;
            Succeeded = succeeded;
            Messages = messages;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }
        public static PaginatedResult<T> Success(List<T> data, int count, int page, int pageSize)
        {
            // contractor PaginatedResult
            return new(true, data, null, count, page, pageSize);
        }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageCount { get; set; }
        public object Meta { get; set; }
        public int PageSize { get; set; }
        public bool HasPreviouesPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;
        public List<string> Messages { get; set; } = new();
        public bool Succeeded { get; set; }

    }
}
