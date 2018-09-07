namespace ESH.CLI.Models
{
    public class ResponseBase<T> where T : class
    {
        public bool IsSucess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}