namespace CheckSPNs.Client.Data.Model
{
    public class Response<T>
    {
        public T value { get; set; }
        public bool isSuccess { get; set; }
        public bool isFailure => !isSuccess;
        public ErrorDetails error { get; set; }
    }
}
