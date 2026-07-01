namespace System.IO;

public class NonUIProgress<T>(Action<T> action) : IProgress<T>
{
    public void Report(T value)
    {
        action(value);
    }
}