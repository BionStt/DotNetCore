namespace DotNetCore.Objects
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        protected DataResult() { }

        public T Data { get; protected set; }

        public static new IDataResult<T> Fail()
        {
            return new DataResult<T> { Failed = true, Succeeded = false };
        }

        public static new IDataResult<T> Fail(string message)
        {
            return new DataResult<T> { Failed = true, Succeeded = false, Message = message };
        }

        public static new IDataResult<T> Success()
        {
            return new DataResult<T> { Failed = false, Succeeded = true };
        }

        public static new IDataResult<T> Success(string message)
        {
            return new DataResult<T> { Failed = false, Succeeded = true, Message = message };
        }

        public static IDataResult<T> Success(T data)
        {
            return new DataResult<T> { Failed = false, Succeeded = true, Data = data };
        }

        public static IDataResult<T> Success(T data, string message)
        {
            return new DataResult<T> { Failed = false, Succeeded = true, Data = data, Message = message };
        }
    }
}
