namespace TManager.service.dto
{
    public class Page<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; } = 10;
        public List<T> Items { get; set; } = new List<T>();
        public int TotalCount { get; set; }

        public static Page<T> of(List<T> items, int PageNumber, int TotalCount)
        {
            Page<T> page = new Page<T>();
            page.Items = items;
            page.PageNumber = PageNumber;
            page.PageSize = items.Count();
            page.TotalCount = TotalCount;
            return page;
        }
    }
}
