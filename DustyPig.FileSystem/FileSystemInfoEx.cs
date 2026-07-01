using System.Runtime.Versioning;

namespace System.IO;

public abstract class FileSystemInfoEx
{
    internal FileSystemInfoEx(FileSystemInfo fsi) => InternalFileSystemInfo = fsi;

    public static implicit operator FileSystemInfo(FileSystemInfoEx val) => val.InternalFileSystemInfo;


    public FileSystemInfo InternalFileSystemInfo { get; }


    public FileAttributes Attributes
    {
        get => InternalFileSystemInfo.Attributes;
        set => InternalFileSystemInfo.Attributes = value;
    }

    public void CreateAsSymbolicLink(string pathToTarget) => InternalFileSystemInfo.CreateAsSymbolicLink(pathToTarget);

    public DateTime CreationTime
    {
        get => InternalFileSystemInfo.CreationTime;
        set => InternalFileSystemInfo.CreationTime = value;
    }

    public DateTime CreationTimeUtc
    {
        get => InternalFileSystemInfo.CreationTimeUtc;
        set => InternalFileSystemInfo.CreationTimeUtc = value;
    }


    public void Delete() => InternalFileSystemInfo.Delete();

    public bool Exists => InternalFileSystemInfo.Exists;

    public string FullName => InternalFileSystemInfo.FullName;

    public DateTime LastAccessTime
    {
        get => InternalFileSystemInfo.LastAccessTime;
        set => InternalFileSystemInfo.LastAccessTime = value;
    }

    public DateTime LastAccessTimeUtc
    {
        get => InternalFileSystemInfo.LastAccessTimeUtc;
        set => InternalFileSystemInfo.LastAccessTimeUtc = value;
    }

    public DateTime LastWriteTime
    {
        get => InternalFileSystemInfo.LastWriteTime;
        set => InternalFileSystemInfo.LastWriteTime = value;
    }

    public DateTime LastWriteTimeUtc
    {
        get => InternalFileSystemInfo.LastWriteTime;
        set => InternalFileSystemInfo.LastWriteTimeUtc = value;
    }

    public string? LinkTargt => InternalFileSystemInfo.LinkTarget;

    public string Name => InternalFileSystemInfo.Name;

    public void Refresh() => InternalFileSystemInfo.Refresh();

    public FileSystemInfoEx? ResolveLinkTarget(bool returnFinalTarget)
    {
        var ret = InternalFileSystemInfo.ResolveLinkTarget(returnFinalTarget);
        if (ret is null)
            return null;

        if (ret.Attributes.HasFlag(FileAttributes.Directory))
            return new DirectoryInfoEx(ret.FullName);
        else
            return new FileInfoEx(ret.FullName);
    }


    [UnsupportedOSPlatform("windows")]
    public UnixFileMode UnixFileMode
    {
        get => InternalFileSystemInfo.UnixFileMode;
        set => InternalFileSystemInfo.UnixFileMode = value;
    }

    public override string ToString()
    {
        return InternalFileSystemInfo.ToString();
    }



    //-------------------------------------

    public string GetRelativePath(DirectoryInfoEx relativeTo) => Path.GetRelativePath(relativeTo.FullName, InternalFileSystemInfo.FullName);

    public string GetRelativePath(string relativeTo) => Path.GetRelativePath(relativeTo, InternalFileSystemInfo.FullName);

    public bool IsPathFullyQualified() => Path.IsPathFullyQualified(InternalFileSystemInfo.FullName);

    public bool IsPathRooted() => Path.IsPathRooted(InternalFileSystemInfo.FullName);

}
