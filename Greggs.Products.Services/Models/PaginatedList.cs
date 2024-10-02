
namespace Greggs.Products.Services.Models
{
    public class PaginatedList<T>
    {
        public List<T> Items { get; set; }
        public int PageStart { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }

        public PaginatedList(List<T> items, int pageStart, int pageSize, int totalPages, int totalRecords)
        {
            Items = items;
            PageStart = pageStart;
            PageSize = pageSize;
            TotalRecords = totalRecords;
            TotalPages = totalPages;
        }
    }
}
