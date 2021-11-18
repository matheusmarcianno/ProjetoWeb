using System.Collections.Generic;

namespace Shared.Results
{
    public class DataResult<T> : Result
    {
        public List<T> Data { get; set; }
        
        public DataResult(string message, bool success, List<T> data) : base(message, success)
        {
            this.Data = data;
        }
    }
}
