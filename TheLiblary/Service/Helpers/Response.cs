﻿namespace TheLiblary.Service.Helpers
{
    internal class Response<T>
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
    }
}
