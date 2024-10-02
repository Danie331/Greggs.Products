using System.Collections.Generic;

namespace Greggs.Products.Api.Models
{
    public class PaginatedList<T>
    {
        public List<T> Items { get; set;  }
        public int PageStart { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }
}
