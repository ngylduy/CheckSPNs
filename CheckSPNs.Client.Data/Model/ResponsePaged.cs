﻿namespace CheckSPNs.Client.Data.Model
{
    public class ResponsePaged<TResult>
    {
        public DataPaged<TResult> value { get; set; }
        public bool isSuccess { get; set; }
        public bool isFailure => !isSuccess;
        public ErrorDetails error { get; set; }
    }
}
