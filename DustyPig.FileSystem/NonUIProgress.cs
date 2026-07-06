namespace System.IO;

internal class NonUIProgress<T>(Action<T> action) : IProgress<T>
{
    public void Report(T value)
    {
        action(value);
    }
}