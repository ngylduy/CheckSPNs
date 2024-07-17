namespace CheckSPNs.Client.Data.Model
{
    public class ResponseList<T>
    {
        public List<T> value { get; set; }
        public bool isSuccess { get; set; }
        public bool isFailure => !isSuccess;
        public ErrorDetails error { get; set; }
    }
}
