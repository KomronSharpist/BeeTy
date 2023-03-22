namespace BeeTy.Service.Helpers
{
    public class Response<TResult>
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public TResult Value { get; set; }
    }
}
