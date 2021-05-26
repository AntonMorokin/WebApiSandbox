namespace Core.Common
{
    public sealed class SimpleResult<T>
    {
        public bool Success { get; set; }

        public T Result { get; set; }
    }
}
