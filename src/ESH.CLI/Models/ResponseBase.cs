namespace ESH.CLI.Models
{
    public class ResponseBase<T>
    {
        public bool IsSucess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}