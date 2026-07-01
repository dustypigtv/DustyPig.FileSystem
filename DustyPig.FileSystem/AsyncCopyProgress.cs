namespace System.IO;

public class AsyncCopyProgress
{
    internal AsyncCopyProgress(long bytesCopied, long totalBytes, DateTime started)
    {
        BytesCopied = bytesCopied;
        TotalBytes = totalBytes;
        Elapsed = DateTime.Now - started;

        Remaining = TimeSpan.MaxValue;
        if (TotalBytes > 0)
        {
            Progress = (double)BytesCopied / TotalBytes;
            BytesPerSecond = bytesCopied / (DateTime.Now - started).TotalSeconds;
            if (BytesPerSecond > 0)
                Remaining = TimeSpan.FromSeconds((TotalBytes - bytesCopied) / BytesPerSecond);
        }
    }

    public long BytesCopied { get; }

    public long TotalBytes { get; }

    public double Progress { get; }

    public double BytesPerSecond { get; }

    public TimeSpan Elapsed { get; }

    public TimeSpan Remaining { get; }
}