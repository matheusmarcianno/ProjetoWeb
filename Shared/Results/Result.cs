namespace Shared.Results
{
    public class Result
    {
        public string Message { get; set; }
        public bool Success { get; set; }

        public Result(string message, bool success)
        {
            this.Message = message;
            this.Success = success;
        }

        public override string ToString() => this.Message;
    }
}
