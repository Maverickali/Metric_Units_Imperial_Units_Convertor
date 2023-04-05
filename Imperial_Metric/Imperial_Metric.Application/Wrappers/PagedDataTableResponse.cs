
namespace Imperial_Metric.Application.Wrappers
{
    public class PagedDataTableResponse<T> : Response<T>
    {
        public int Draw { get; set; }
        public int RecordsFiltered { get; set; }
        public int RecordsTotal { get; set; }

    }
}