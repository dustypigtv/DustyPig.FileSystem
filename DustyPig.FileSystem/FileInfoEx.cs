using System.Diagnostics;
using System.Runtime.Versioning;
using System.Text;
using System.Text.Json;

namespace System.IO;

public class FileInfoEx : FileSystemInfoEx
{
    public FileInfoEx(FileInfo fileInfo) : base(fileInfo) { }

    public FileInfoEx(string path) : base(new FileInfo(path)) { }

    public static implicit operator FileInfoEx(FileInfo val) => new(val);

    public static implicit operator FileInfoEx(string val) => new(val);

    public static implicit operator FileInfo(FileInfoEx val) => val.InternalFileInfo;

    public static implicit operator string(FileInfoEx val) => val.FullName;

    public FileInfo InternalFileInfo => (FileInfo)InternalFileSystemInfo;


    public StreamWriter AppendText() => InternalFileInfo.AppendText();

    public FileInfo CopyTo(string destFileName) => InternalFileInfo.CopyTo(destFileName);

    public FileInfo CopyTo(string destFileName, bool overwrite) => InternalFileInfo.CopyTo(destFileName, overwrite);

    public FileStream Create() => InternalFileInfo.Create();

    [SupportedOSPlatform("windows")]
    public FileStream Create(FileMode mode, Security.AccessControl.FileSystemRights rights, FileShare share, int bufferSize, FileOptions options, Security.AccessControl.FileSecurity? fileSecurity) =>
        InternalFileInfo.Create(mode, rights, share, bufferSize, options, fileSecurity);

    public StreamWriter CreateText() => InternalFileInfo.CreateText();

    
    [SupportedOSPlatform("windows")]
    public void Decrypt() => InternalFileInfo.Decrypt();

    public DirectoryInfoEx? Directory => InternalFileInfo.Directory is null ? null : new(InternalFileInfo.Directory.FullName);

    public string? DirectoryName => InternalFileInfo.DirectoryName;


    [SupportedOSPlatform("windows")]
    public void Encrypt() => InternalFileInfo.Encrypt();

    public string Extension => InternalFileInfo.Extension;

    [SupportedOSPlatform("windows")]
    public Security.AccessControl.FileSecurity GetAccessControl() => InternalFileInfo.GetAccessControl();

    [SupportedOSPlatform("windows")]
    public Security.AccessControl.FileSecurity GetAccessControl(Security.AccessControl.AccessControlSections includeSections) => InternalFileInfo.GetAccessControl(includeSections);

    public bool IsReadOnly
    {
        get => InternalFileInfo.IsReadOnly;
        set => InternalFileInfo.IsReadOnly = value;
    }

    public long Length => InternalFileInfo.Length;

    public void MoveTo(string destFileName) => InternalFileInfo.MoveTo(destFileName);

    public void MoveTo(string destFileName, bool overwrite) => InternalFileInfo.MoveTo(destFileName, overwrite);

    public FileStream Open(FileMode mode) => InternalFileInfo.Open(mode);

    public FileStream Open(FileMode mode, FileAccess access) => InternalFileInfo.Open(mode, access);

    public FileStream Open(FileMode mode, FileAccess access, FileShare share) => InternalFileInfo.Open(mode, access, share);

    public FileStream Open(FileStreamOptions options) => InternalFileInfo.Open(options);

    public FileStream OpenRead() => InternalFileInfo.OpenRead();

    public StreamReader OpenText() => InternalFileInfo.OpenText();

    public FileStream OpenWrite() => InternalFileInfo.OpenWrite();

    public FileInfo Replace(string destinationFileName, string? destinationBackupFileName) => InternalFileInfo.Replace(destinationFileName, destinationBackupFileName);

    public FileInfo Replace(string destinationFileName, string? destinationBackupFileName, bool ignoreMetadataErrors) => InternalFileInfo.Replace(destinationFileName, destinationBackupFileName, ignoreMetadataErrors);

    [SupportedOSPlatform("windows")]
    public void SetAccessControl(Security.AccessControl.FileSecurity fileSecurity) => InternalFileInfo.SetAccessControl(fileSecurity);

    public override string ToString()
    {
        return InternalFileInfo.ToString();
    }



    //--------------------------------------------------------------

    private static readonly Encoding DEFAULT_ENCODING = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true);
    private static readonly JsonSerializerOptions DEFAULT_SERIALIZER_OPTIONS = new() { WriteIndented = true };

#if NET9_0_OR_GREATER
    public void AppendAllBytes(byte[] bytes)
    {
        InternalFileInfo.Directory?.Create();
        File.AppendAllBytes(InternalFileInfo.FullName, bytes);
    }

    public Task AppendAllBytesAsync(byte[] bytes, CancellationToken cancellationToken = default)
    {
        InternalFileInfo.Directory?.Create();
        return File.AppendAllBytesAsync(InternalFileInfo.FullName, bytes, cancellationToken);
    }


    public void AppendAllBytes(ReadOnlySpan<byte> bytes)
    {
        InternalFileInfo.Directory?.Create();
        File.AppendAllBytes(InternalFileInfo.FullName, bytes);
    }

    public Task AppendAllBytesAsync(ReadOnlyMemory<byte> bytes, CancellationToken cancellationToken = default)
    {
        InternalFileInfo.Directory?.Create();
        return File.AppendAllBytesAsync(InternalFileInfo.FullName, bytes, cancellationToken);
    }
#endif


    public void AppendAllLines(IEnumerable<string> contents, Encoding? encoding = null)
    {
        InternalFileInfo.Directory?.Create();
        File.AppendAllLines(InternalFileInfo.FullName, contents, encoding ?? DEFAULT_ENCODING);
    }

    public Task AppendAllLinesAsync(IEnumerable<string> contents, Encoding? encoding = null, CancellationToken cancellationToken = default)
    {
        InternalFileInfo.Directory?.Create();
        return File.AppendAllLinesAsync(InternalFileInfo.FullName, contents, encoding ?? DEFAULT_ENCODING, cancellationToken);
    }

    public void AppendAllText(string? contents, Encoding? encoding = null)
    {
        InternalFileInfo.Directory?.Create();
        File.AppendAllText(InternalFileInfo.FullName, contents, encoding ?? DEFAULT_ENCODING);
    }

    public Task AppendAllTextAsync(string? contents, Encoding? encoding = null, CancellationToken cancellationToken = default)
    {
        InternalFileInfo.Directory?.Create();
        return File.AppendAllTextAsync(InternalFileInfo.FullName, contents, encoding ?? DEFAULT_ENCODING, cancellationToken);
    }

#if NET9_0_OR_GREATER
    public void AppendAllText(ReadOnlySpan<char> contents, Encoding? encoding = null)
    {
        InternalFileInfo.Directory?.Create();
        File.AppendAllText(InternalFileInfo.FullName, contents, encoding ?? DEFAULT_ENCODING);
    }
    
    public Task AppendAllTextAsync(ReadOnlyMemory<char> contents, Encoding? encoding = null, CancellationToken cancellationToken = default)
    {
        InternalFileInfo.Directory?.Create();
        return File.AppendAllTextAsync(InternalFileInfo.FullName, contents, encoding ?? DEFAULT_ENCODING, cancellationToken);
    }
#endif

    public FileStream Create(int bufferSize)
    {
        InternalFileInfo.Directory?.Create();
        return File.Create(InternalFileInfo.FullName, bufferSize);
    }

    public FileStream Create(int bufferSize, FileOptions options)
    {
        InternalFileInfo.Directory?.Create();
        return File.Create(InternalFileInfo.FullName, bufferSize, options);
    }


    public bool TryDelete()
    {
        try
        {
            InternalFileInfo.Delete();
            return true;
        }
        catch { }
        return false;
    }

   
    public Microsoft.Win32.SafeHandles.SafeFileHandle OpenHandle(FileMode mode = FileMode.Open, FileAccess access = FileAccess.Read, FileShare share = FileShare.Read, FileOptions options = FileOptions.None, long preallocationSize = 0)
    {
        if(mode == FileMode.Append || mode == FileMode.Create || mode == FileMode.CreateNew || mode == FileMode.OpenOrCreate)
            InternalFileInfo.Directory?.Create();
        return File.OpenHandle(InternalFileInfo.FullName, mode, access, share, options, preallocationSize);
    }

    public byte[] ReadAllBytes() => File.ReadAllBytes(InternalFileInfo.FullName);

    public Task<byte[]> ReadAllBytesAsync(CancellationToken cancellationToken = default) => File.ReadAllBytesAsync(InternalFileInfo.FullName, cancellationToken);

    public string[] ReadAllLines(Encoding? encoding = null) => File.ReadAllLines(InternalFileInfo.FullName, encoding ?? DEFAULT_ENCODING);

    public Task<string[]> ReadAllLinesAsync(Encoding? encoding = null, CancellationToken cancellationToken = default) => File.ReadAllLinesAsync(InternalFileInfo.FullName, encoding ?? DEFAULT_ENCODING, cancellationToken);

    public string ReadAllText(Encoding? encoding = null) => File.ReadAllText(InternalFileInfo.FullName, encoding ?? DEFAULT_ENCODING);

    public Task<string> ReadAllTextAsync(Encoding? encoding = null, CancellationToken cancellationToken = default) => File.ReadAllTextAsync(InternalFileInfo.FullName, encoding ?? DEFAULT_ENCODING, cancellationToken);

    public IEnumerable<string> ReadLines(Encoding? encoding = null) => File.ReadLines(InternalFileInfo.FullName, encoding ?? DEFAULT_ENCODING);

    public IAsyncEnumerable<string> ReadLinesAsync(Encoding? encoding = null, CancellationToken cancellationToken = default) =>
        File.ReadLinesAsync(InternalFileInfo.FullName, encoding ?? DEFAULT_ENCODING, cancellationToken);

    public void WriteAllBytes(byte[] bytes)
    {
        InternalFileInfo.Directory?.Create();
        File.WriteAllBytes(InternalFileInfo.FullName, bytes);
    }

    public Task WriteAllBytesAsync(byte[] bytes, CancellationToken cancellationToken = default)
    {
        InternalFileInfo.Directory?.Create();
        return File.WriteAllBytesAsync(InternalFileInfo.FullName, bytes, cancellationToken);
    }

#if NET9_0_OR_GREATER
    public void WriteAllBytes(ReadOnlySpan<byte> bytes)
    {
        InternalFileInfo.Directory?.Create();
        File.WriteAllBytes(InternalFileInfo.FullName, bytes);
    }

    public Task WriteAllBytes(ReadOnlyMemory<byte> bytes, CancellationToken cancellationToken = default)
    {
        InternalFileInfo.Directory?.Create();
        return File.WriteAllBytesAsync(InternalFileInfo.FullName, bytes, cancellationToken);
    }
#endif

    public void WriteAllLines(IEnumerable<string> contents, Encoding? encoding = null)
    {
        InternalFileInfo.Directory?.Create();
        File.WriteAllLines(InternalFileInfo.FullName, contents, encoding ?? DEFAULT_ENCODING);
    }

    public Task WriteAllLinesAsync(IEnumerable<string> contents, Encoding? encoding = null, CancellationToken cancellationToken = default)
    {
        InternalFileInfo.Directory?.Create();
        return File.WriteAllLinesAsync(InternalFileInfo.FullName, contents, encoding ?? DEFAULT_ENCODING, cancellationToken);
    }

    public void WriteAllText(string? contents, Encoding? encoding = null)
    {
        InternalFileInfo.Directory?.Create();
        File.WriteAllText(InternalFileInfo.FullName, contents, encoding ?? DEFAULT_ENCODING);
    }

#if NET9_0_OR_GREATER
    public void WriteAllText(ReadOnlySpan<char> contents, Encoding? encoding = null)
    {
        InternalFileInfo.Directory?.Create();
        File.WriteAllText(InternalFileInfo.FullName, contents, encoding ?? DEFAULT_ENCODING);
    }

    public Task WriteAllTextAsync(ReadOnlyMemory<char> contents, Encoding? encoding = null, CancellationToken cancellationToken = default)
    {
        InternalFileInfo.Directory?.Create();
        return File.WriteAllTextAsync(InternalFileInfo.FullName, contents, encoding ?? DEFAULT_ENCODING, cancellationToken);
    }
#endif

    public Task WriteAllTextAsync(string? contents, Encoding? encoding = null, CancellationToken cancellationToken = default)
    {
        InternalFileInfo.Directory?.Create();
        return File.WriteAllTextAsync(InternalFileInfo.FullName, contents, encoding ?? DEFAULT_ENCODING, cancellationToken);
    }

    
    

    public T? ReadJson<T>(JsonSerializerOptions? options = null)
    {
        return JsonSerializer.Deserialize<T>(ReadAllText(), options ?? DEFAULT_SERIALIZER_OPTIONS);
    }

    public async ValueTask<T?> ReadJsonAsync<T>(JsonSerializerOptions? options = null, CancellationToken cancellationToken = default)
    {
        await using var stream = OpenRead();
        return await JsonSerializer.DeserializeAsync<T>(stream, options ?? DEFAULT_SERIALIZER_OPTIONS, cancellationToken).ConfigureAwait(false);
    }

    public void WriteJson(object value, JsonSerializerOptions? options = null)
    {
        WriteAllText(JsonSerializer.Serialize(value, options ?? DEFAULT_SERIALIZER_OPTIONS));
    }


    public async Task WriteJsonAsync(object value, JsonSerializerOptions? options = null, CancellationToken cancellationToken = default)
    {
        InternalFileInfo.Directory?.Create();
        await using var stream = OpenWrite();
        await JsonSerializer.SerializeAsync(stream, value, options ?? DEFAULT_SERIALIZER_OPTIONS, cancellationToken).ConfigureAwait(false);
    }


    public void Truncate()
    {
        InternalFileInfo.Directory?.Create();
        new FileStream(InternalFileInfo.FullName, FileMode.Create).Dispose();
    }


    public void Touch(DateTime? dt = null)
    {
        InternalFileInfo.Directory?.Create();
        InternalFileInfo.Refresh();
        if (!InternalFileInfo.Exists)
        {
            new FileStream(InternalFileInfo.FullName, FileMode.Create).Dispose();
            if (dt is null)
                return;
        }

        dt ??= DateTime.Now;
        InternalFileInfo.CreationTime = dt.Value;
        InternalFileInfo.LastWriteTime = dt.Value;
        InternalFileInfo.LastAccessTime = dt.Value;
    }


    public bool TryTouch(DateTime? dt = null)
    {
        try
        {
            Touch(dt);
            return true;
        }
        catch { }
        return false;
    }


    /// <summary>
    /// Returns a new <see cref="FileInfoEx"/> with the new <paramref name="newExtension"/>. This does NOT modify files on disk
    /// </summary>
    public FileInfoEx ChangeExtension(string newExtension) => new(Path.ChangeExtension(InternalFileInfo.FullName, newExtension));

    /// <summary>
    /// Returns a new <see cref="FileInfo"/> with the new <paramref name="newName"/>. This does NOT modify files on disk
    /// </summary>
    public FileInfoEx ChangeFilename(string newName)
    {
        if (InternalFileInfo.Directory is null)
            return new FileInfoEx(newName);
        return new(Path.Combine(InternalFileInfo.Directory!.FullName, newName));
    }

    public string GetFilenameWithoutExtension() => Path.GetFileNameWithoutExtension(InternalFileInfo.Name);

    public bool IsFileLocked()
    {
        InternalFileInfo.Refresh();
        if (!InternalFileInfo.Exists)
            return false;

        try
        {
            InternalFileInfo.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None).Dispose();
            return false;
        }
        catch
        {
            return true;
        }
    }


    public void CopyTo(FileInfoEx dest, bool overwrite)
    {
        dest.Directory?.Create();
        InternalFileInfo.CopyTo(dest.FullName, overwrite);
        dest.Refresh();
    }

    public void MoveTo(FileInfoEx dest, bool overwrite)
    {
        dest.Directory?.Create();
        InternalFileInfo.MoveTo(dest.FullName, overwrite);
        dest.Refresh();
    }



    public async Task CopyToAsync(FileInfoEx destFile, IProgress<AsyncCopyProgress>? progress = null, bool overwrite = false, CancellationToken cancellationToken = default)
    {
        bool deleteOnFail = false;
        try
        {
            DateTime started = DateTime.Now;

            //Ensure dest dir
            destFile.Directory?.Create();

            //open the source
            await using var srcStream = new FileStream(InternalFileInfo.FullName, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, FileOptions.Asynchronous | FileOptions.SequentialScan);
        
            //create the destination file stream
            var options = new FileStreamOptions
            {
                Mode = overwrite ? FileMode.Create : FileMode.CreateNew,
                Access = FileAccess.Write,
                Options = FileOptions.Asynchronous | FileOptions.SequentialScan,
                BufferSize = 4096,
                PreallocationSize = InternalFileInfo.Length,
                Share = FileShare.None
            };
            await using var dstStream = new FileStream(destFile.FullName, options);
            deleteOnFail = true;

            //copy

            var buffer = new byte[4096];
            long totalRead = 0;
            long totalLength = InternalFileInfo.Length;
            while (true)
            {
                int read = await srcStream.ReadAsync(buffer, cancellationToken).ConfigureAwait(false);
                if (read < 1)
                    break;

                await dstStream.WriteAsync(buffer.AsMemory(0, read), cancellationToken).ConfigureAwait(false);
                totalRead += read;
                progress?.Report(new AsyncCopyProgress(totalRead, totalLength, started));
            }
        }
        catch
        {
            //delete if failed
            if (deleteOnFail)
                destFile.TryDelete();
            throw;
        }
        finally
        {
            destFile.Refresh();
        }
    }
}
