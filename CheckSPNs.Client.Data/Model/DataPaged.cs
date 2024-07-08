namespace CheckSPNs.Client.Data.Model
{
    public class DataPaged<T>
    {
        public List<T> items { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public int totalCount { get; set; }
        public bool hasPreviousPage { get; set; }
        public bool hasNextPage { get; set; }
    }
}
