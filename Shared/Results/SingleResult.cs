namespace Shared.Results
{
    public class SingleResult<T> : Result
    {
        public T Value { get; set; }
        
        public SingleResult(string message, bool success, T value) : base(message, success)
        {
            this.Value = value;
        }
    }
}
