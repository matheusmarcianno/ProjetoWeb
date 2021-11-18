using System.Collections.Generic;
using System.Linq;
using Shared.Results;

namespace Shared.Factory
{
    public static class ResultFactory
    {
        private static string _successMessage = "Success";
        private static string _failureMessage = "Failure";

        public static Result CreateSuccessResult()
        {
            return new Result(message: _successMessage, success: true);
        }

        public static Result CreateFailureResult()
        {
            return new Result(message: _successMessage, success: false);
        }

        public static SingleResult<T> CreateSuccessSingleResult<T>(T obj)
        {
            return new SingleResult<T>(message: _successMessage, success: true, value: obj);
        }

        public static SingleResult<T> CreateFailureSingleResult<T>()
        {
            return new SingleResult<T>(message: _successMessage, success: false, value: default);
        }

        public static SingleResult<T> CreateFailureSingleResult<T>(T value)
        {
            return new SingleResult<T>(message: _successMessage, success: false, value: value);
        }

        public static DataResult<T> CreateSuccessDataResult<T>(params T[] objects)
        {
            return new DataResult<T>(message: _successMessage, success: true, data: objects.ToList());
        }

        public static DataResult<T> CreateSuccessDataResult<T>(List<T> objectList)
        {
            return new DataResult<T>(message: _successMessage, success: true, data: objectList);
        }

        public static DataResult<T> CreateFailureDataResult<T>()
        {
            return new DataResult<T>(message: _failureMessage, success: false, data: default);
        }

        public static DataResult<T> CreateFailureDataResult<T>(params T[] data)
        {
            return new DataResult<T>(message: _failureMessage, success: false, data: data.ToList());
        }
    }
}
