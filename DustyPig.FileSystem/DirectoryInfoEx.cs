using System.Diagnostics;
using System.Runtime.Versioning;

namespace System.IO;

public class DirectoryInfoEx : FileSystemInfoEx
{
    public DirectoryInfoEx(DirectoryInfo dirInfo) : base(dirInfo) { }

    public DirectoryInfoEx(string path) : base(new DirectoryInfo(path)) { }

    public DirectoryInfoEx(Environment.SpecialFolder specialFolder) : base(new DirectoryInfo(Environment.GetFolderPath(specialFolder))) { }

    public static implicit operator DirectoryInfoEx(DirectoryInfo val) => new(val);

    public static implicit operator DirectoryInfoEx(string val) => new(val);

    public static implicit operator DirectoryInfo(DirectoryInfoEx val) => val.InternalDirectoryInfo;

    public static implicit operator string(DirectoryInfoEx val) => val.FullName;

    public static implicit operator DirectoryInfoEx(Environment.SpecialFolder specialFolder) => new(specialFolder);


    public DirectoryInfo InternalDirectoryInfo => (DirectoryInfo)InternalFileSystemInfo;



    public void Create() => InternalDirectoryInfo.Create();

    [SupportedOSPlatform("windows")]
    public void Create(Security.AccessControl.DirectorySecurity directorySecurity) => InternalDirectoryInfo.Create(directorySecurity);

    public DirectoryInfoEx CreateSubdirectory(string path) => InternalDirectoryInfo.CreateSubdirectory(path);

    public void Delete(bool recursive) => InternalDirectoryInfo.Delete(recursive);

    public IEnumerable<DirectoryInfoEx> EnumerateDirectories()
    {
        foreach (var dir in InternalDirectoryInfo.EnumerateDirectories())
            yield return dir;
    }

    public IEnumerable<DirectoryInfoEx> EnumerateDirectories(string searchPattern)
    {
        foreach (var dir in InternalDirectoryInfo.EnumerateDirectories(searchPattern))
            yield return dir;
    }

    public IEnumerable<DirectoryInfoEx> EnumerateDirectories(string searchPattern, SearchOption searchOption)
    {
        foreach (var dir in InternalDirectoryInfo.EnumerateDirectories(searchPattern, searchOption))
            yield return dir;
    }

    public IEnumerable<DirectoryInfoEx> EnumerateDirectories(string searchPattern, EnumerationOptions enumerationOptions)
    {
        foreach (var dir in InternalDirectoryInfo.EnumerateDirectories(searchPattern, enumerationOptions))
            yield return dir;
    }


    public IEnumerable<FileInfoEx> EnumerateFiles()
    {
        foreach (var file in InternalDirectoryInfo.EnumerateFiles())
            yield return file;
    }

    public IEnumerable<FileInfoEx> EnumerateFiles(string searchPattern)
    {
        foreach (var file in InternalDirectoryInfo.EnumerateFiles(searchPattern))
            yield return file;
    }

    public IEnumerable<FileInfoEx> EnumerateFiles(string searchPattern, SearchOption searchOption)
    {
        foreach (var file in InternalDirectoryInfo.EnumerateFiles(searchPattern, searchOption))
            yield return file;
    }

    public IEnumerable<FileInfoEx> EnumerateFiles(string searchPattern, EnumerationOptions enumerationOptions)
    {
        foreach (var file in InternalDirectoryInfo.EnumerateFiles(searchPattern, enumerationOptions))
            yield return file;
    }


    public IEnumerable<FileSystemInfoEx> EnumerateFileSystemInfos()
    {
        foreach (var fsi in InternalDirectoryInfo.EnumerateFileSystemInfos())
            if (fsi.Attributes.HasFlag(FileAttributes.Directory))
                yield return new DirectoryInfoEx(fsi.FullName);
    }

    public IEnumerable<FileSystemInfoEx> EnumerateFileSystemInfos(string searchPattern)
    {
        foreach (var fsi in InternalDirectoryInfo.EnumerateFileSystemInfos(searchPattern))
            if (fsi.Attributes.HasFlag(FileAttributes.Directory))
                yield return new DirectoryInfoEx(fsi.FullName);
    }

    public IEnumerable<FileSystemInfoEx> EnumerateFileSystemInfos(string searchPattern, SearchOption searchOption)
    {
        foreach (var fsi in InternalDirectoryInfo.EnumerateFileSystemInfos(searchPattern, searchOption))
            if (fsi.Attributes.HasFlag(FileAttributes.Directory))
                yield return new DirectoryInfoEx(fsi.FullName);
    }

    public IEnumerable<FileSystemInfoEx> EnumerateFileSystemInfos(string searchPattern, EnumerationOptions enumerationOptions)
    {
        foreach (var fsi in InternalDirectoryInfo.EnumerateFileSystemInfos(searchPattern, enumerationOptions))
            if (fsi.Attributes.HasFlag(FileAttributes.Directory))
                yield return new DirectoryInfoEx(fsi.FullName);
    }


    [SupportedOSPlatform("windows")]
    public Security.AccessControl.DirectorySecurity GetAccessControl() => InternalDirectoryInfo.GetAccessControl();

    [SupportedOSPlatform("windows")]
    public Security.AccessControl.DirectorySecurity GetAccessControl(Security.AccessControl.AccessControlSections includeSections) => InternalDirectoryInfo.GetAccessControl(includeSections);


    public DirectoryInfoEx[] GetDirectories()
    {
        var dirs = InternalDirectoryInfo.GetDirectories();
        var ret = new DirectoryInfoEx[dirs.Length];
        for (int i = 0; i < dirs.Length; i++)
            ret[i] = dirs[i];
        return ret;
    }

    public DirectoryInfoEx[] GetDirectories(string searchPattern)
    {
        var dirs = InternalDirectoryInfo.GetDirectories(searchPattern);
        var ret = new DirectoryInfoEx[dirs.Length];
        for (int i = 0; i < dirs.Length; i++)
            ret[i] = dirs[i];
        return ret;
    }

    public DirectoryInfoEx[] GetDirectories(string searchPattern, SearchOption searchOption)
    {
        var dirs = InternalDirectoryInfo.GetDirectories(searchPattern, searchOption);
        var ret = new DirectoryInfoEx[dirs.Length];
        for (int i = 0; i < dirs.Length; i++)
            ret[i] = dirs[i];
        return ret;
    }

    public DirectoryInfoEx[] GetDirectories(string searchPattern, EnumerationOptions enumerationOptions)
    {
        var dirs = InternalDirectoryInfo.GetDirectories(searchPattern, enumerationOptions);
        var ret = new DirectoryInfoEx[dirs.Length];
        for (int i = 0; i < dirs.Length; i++)
            ret[i] = dirs[i];
        return ret;
    }

    public FileInfoEx[] GetFiles()
    {
        var dirs = InternalDirectoryInfo.GetFiles();
        var ret = new FileInfoEx[dirs.Length];
        for (int i = 0; i < dirs.Length; i++)
            ret[i] = dirs[i];
        return ret;
    }

    public FileInfoEx[] GetFiles(string searchPattern)
    {
        var dirs = InternalDirectoryInfo.GetFiles(searchPattern);
        var ret = new FileInfoEx[dirs.Length];
        for (int i = 0; i < dirs.Length; i++)
            ret[i] = dirs[i];
        return ret;
    }

    public FileInfoEx[] GetFiles(string searchPattern, SearchOption searchOption)
    {
        var dirs = InternalDirectoryInfo.GetFiles(searchPattern, searchOption);
        var ret = new FileInfoEx[dirs.Length];
        for (int i = 0; i < dirs.Length; i++)
            ret[i] = dirs[i];
        return ret;
    }

    public FileInfoEx[] GetFiles(string searchPattern, EnumerationOptions enumerationOptions)
    {
        var dirs = InternalDirectoryInfo.GetFiles(searchPattern, enumerationOptions);
        var ret = new FileInfoEx[dirs.Length];
        for (int i = 0; i < dirs.Length; i++)
            ret[i] = dirs[i];
        return ret;
    }


    public FileSystemInfoEx[] GetFileSystemInfos()
    {
        var fsis = InternalDirectoryInfo.GetFileSystemInfos();
        var ret = new FileSystemInfoEx[fsis.Length];
        for (int i = 0; i < fsis.Length; i++)
            if (fsis[i].Attributes.HasFlag(FileAttributes.Directory))
                ret[i] = new DirectoryInfoEx(fsis[i].FullName);
            else
                ret[i] = new FileInfoEx(fsis[i].FullName);
        return ret;
    }

    public FileSystemInfoEx[] GetFileSystemInfos(string searchPattern)
    {
        var fsis = InternalDirectoryInfo.GetFileSystemInfos(searchPattern);
        var ret = new FileSystemInfoEx[fsis.Length];
        for (int i = 0; i < fsis.Length; i++)
            if (fsis[i].Attributes.HasFlag(FileAttributes.Directory))
                ret[i] = new DirectoryInfoEx(fsis[i].FullName);
            else
                ret[i] = new FileInfoEx(fsis[i].FullName);
        return ret;
    }

    public FileSystemInfoEx[] GetFileSystemInfos(string searchPattern, SearchOption searchOption)
    {
        var fsis = InternalDirectoryInfo.GetFileSystemInfos(searchPattern, searchOption);
        var ret = new FileSystemInfoEx[fsis.Length];
        for (int i = 0; i < fsis.Length; i++)
            if (fsis[i].Attributes.HasFlag(FileAttributes.Directory))
                ret[i] = new DirectoryInfoEx(fsis[i].FullName);
            else
                ret[i] = new FileInfoEx(fsis[i].FullName);
        return ret;
    }

    public FileSystemInfoEx[] GetFileSystemInfos(string searchPattern, EnumerationOptions enumerationOptions)
    {
        var fsis = InternalDirectoryInfo.GetFileSystemInfos(searchPattern, enumerationOptions);
        var ret = new FileSystemInfoEx[fsis.Length];
        for (int i = 0; i < fsis.Length; i++)
            if (fsis[i].Attributes.HasFlag(FileAttributes.Directory))
                ret[i] = new DirectoryInfoEx(fsis[i].FullName);
            else
                ret[i] = new FileInfoEx(fsis[i].FullName);
        return ret;
    }




    public void MoveTo(string destDirName) => InternalDirectoryInfo.MoveTo(destDirName);

    public DirectoryInfoEx? Parent => InternalDirectoryInfo.Parent is null ? null : new(InternalDirectoryInfo.Parent);

    public DirectoryInfoEx Root => InternalDirectoryInfo.Root;

    [SupportedOSPlatform("windows")]
    public void SetAccessControl(Security.AccessControl.DirectorySecurity directorySecurity) => InternalDirectoryInfo.SetAccessControl(directorySecurity);

    public override string ToString()
    {
        return InternalDirectoryInfo.ToString();
    }








    //-----------------------




    [SupportedOSPlatform("windows")]
    public void OpenInExplorer()
    {
        if (OperatingSystem.IsWindows())
            Process.Start("explorer.exe", $"\"{InternalDirectoryInfo.FullName}\"");
    }

    /// <summary>
    /// Ensures the directory exists and sets the date/time
    /// </summary>
    /// <param name="dt">The date/time to use. If not specified, the current system time is used</param>
    /// <param name="recursive">Whether to set the date/time on all sub directories and files</param>
    public void Touch(DateTime? dt = null, bool recursive = false)
    {
        InternalDirectoryInfo.Refresh();
        if (!InternalDirectoryInfo.Exists)
        {
            InternalDirectoryInfo.Create();
            if (recursive == false && dt is null)
                return;
        }

        dt ??= DateTime.Now;
        if (recursive)
            foreach (var fsi in AlternativeEnumerateFileSystemInfos("*", SearchOption.AllDirectories))
            {
                fsi.CreationTime = dt.Value;
                fsi.LastWriteTime = dt.Value;
                fsi.LastAccessTime = dt.Value;
            }

        InternalDirectoryInfo.CreationTime = dt.Value;
        InternalDirectoryInfo.LastWriteTime = dt.Value;
        InternalDirectoryInfo.LastAccessTime = dt.Value;
    }


    /// <summary>
    /// Tries to ensure the directory exists and sets the date/time
    /// </summary>
    /// <returns>Wheather or not the operation was successful</returns>
    /// <param name="dt">The date/time to use. If not specified, the current system time is used</param>
    /// <param name="recursive">Whether to set the date/time on all sub directories and files</param>
    public bool TryTouch(DateTime? dt = null, bool recursive = false)
    {
        try
        {
            Touch(dt, recursive);
            return true;
        }
        catch { }
        return false;
    }

    /// <summary>
    /// Returns a new <see cref="DirectoryInfo"/> without creating the directories
    /// </summary>
    public DirectoryInfoEx ChildDirectory(params string[] parts)
    {
        var partsLst = parts.ToList();
        partsLst.Insert(0, InternalDirectoryInfo.FullName);
        return new DirectoryInfoEx(Path.Combine([.. partsLst]));
    }

    /// <summary>
    /// Returns a new <see cref="FileInfo"/> without creating the file
    /// </summary>
    public FileInfoEx ChildFile(params string[] parts)
    {
        var partsLst = parts.ToList();
        partsLst.Insert(0, InternalDirectoryInfo.FullName);
        return new FileInfoEx(Path.Combine([.. partsLst]));
    }

    /// <summary>
    /// Deletes all empty folders in the sub-tree the specified <paramref name="dirInfo"/>
    /// </summary>
    /// <param name="dirInfo"></param>
    public void DeleteEmptyDirectories(bool keepRoot = false)
    {
        //Core only deletes dir when depth = 0, so pass 1 when keepRoot = true
        DeleteEmptyDirectoriesCore(this, (ulong)(keepRoot ? 1 : 0));
    }

    private static void DeleteEmptyDirectoriesCore(DirectoryInfoEx parentDir, ulong depth)
    {
        parentDir.Refresh();
        if (!parentDir.Exists)
            return;

        foreach (var childDir in parentDir.GetDirectories())
        {
            DeleteEmptyDirectoriesCore(childDir, depth + 1);
            childDir.TryDelete(false);
        }

        if (depth == 0)
            parentDir.TryDelete(false);
    }

    public bool TryDelete(bool recursive = false)
    {
        try
        {
            InternalDirectoryInfo.Delete(recursive);
            return true;
        }
        catch { }

        return false;
    }


    public FileInfoEx GetUniqueFilename(string ext = ".tmp")
    {
        if (string.IsNullOrWhiteSpace(ext))
            ext = ".tmp";

        if (!ext.StartsWith('.'))
            ext = '.' + ext;

        while (true)
        {
            var ret = ChildFile(Guid.NewGuid().ToString("N").ToLower() + ext);
            if (!ret.Exists)
                return ret;
        }
    }

    public DirectoryInfoEx GetUniqueDirectoryname()
    {
        while (true)
        {
            var ret = ChildDirectory(Guid.NewGuid().ToString("N").ToLower());
            if (!ret.Exists)
                return ret;
        }
    }


    /// <summary>
    /// Sometimes the built in <see cref="DirectoryInfo.EnumerateFiles"/> can fail, for example on an Rclone mount when <see cref="SearchOption.AllDirectories"/> is specified. This tries to fix that
    /// </summary>
    /// <returns>An enumerable collection of files that matches searchPattern.</returns>
    /// <param name="searchPattern">
    /// The search string to match against the names of files. This parameter can contain
    /// a combination of valid literal path and wildcard (* and ?) characters, but it
    /// doesn't support regular expressions.
    /// </param>
    /// <param name="searchOption">An object that describes the search and enumeration configuration to use.</param>
    public IEnumerable<FileInfoEx> AlternativeEnumerateFiles(string searchPattern = "*", SearchOption searchOption = SearchOption.TopDirectoryOnly)
    {
        InternalDirectoryInfo.Refresh();
        if (!InternalDirectoryInfo.Exists)
            yield break;

        var q = new Queue<DirectoryInfoEx>();
        q.Enqueue(this);

        while (q.TryDequeue(out var curDir))
        {
            curDir.Refresh();
            if (!curDir.Exists)
                continue;

            if (searchOption == SearchOption.AllDirectories)
                foreach (var subDir in curDir.GetDirectories())
                    q.Enqueue(subDir);

            foreach (var file in curDir.GetFiles(searchPattern))
                yield return file;
        }
    }


    /// <summary>
    /// Sometimes the built in <see cref="DirectoryInfo.EnumerateDirectories"/> can fail, for example on an Rclone mount when <see cref="SearchOption.AllDirectories"/> is specified. This tries to fix that
    /// </summary>
    /// <returns>An enumerable collection of directories that matches searchPattern.</returns>
    /// <param name="searchPattern">
    /// The search string to match against the names of directories. This parameter can contain
    /// a combination of valid literal path and wildcard (* and ?) characters, but it
    /// doesn't support regular expressions.
    /// </param>
    /// <param name="searchOption">An object that describes the search and enumeration configuration to use.</param>
    public IEnumerable<DirectoryInfoEx> AlternativeEnumerateDirectories(string searchPattern = "*", SearchOption searchOption = SearchOption.TopDirectoryOnly)
    {
        InternalDirectoryInfo.Refresh();
        if (!InternalDirectoryInfo.Exists)
            yield break;

        var q = new Queue<DirectoryInfoEx>();
        q.Enqueue(this);

        while (q.TryDequeue(out var curDir))
        {
            curDir.Refresh();
            if (!curDir.Exists)
                continue;

            if (searchOption == SearchOption.AllDirectories)
                foreach (var subDir in curDir.GetDirectories())
                    q.Enqueue(subDir);

            foreach (var subDir in curDir.GetDirectories(searchPattern))
                yield return subDir;
        }
    }

    /// <summary>
    /// Sometimes the built in <see cref="DirectoryInfo.EnumerateFileSystemInfos"/> can fail, for example on an Rclone mount when <see cref="SearchOption.AllDirectories"/> is specified. This tries to fix that
    /// </summary>
    /// <returns>An enumerable collection of file system information that matches searchPattern.</returns>
    /// <param name="searchPattern">
    /// The search string to match against the names of directories and files. This parameter can contain
    /// a combination of valid literal path and wildcard (* and ?) characters, but it
    /// doesn't support regular expressions.
    /// </param>
    /// <param name="searchOption">An object that describes the search and enumeration configuration to use.</param>
    public IEnumerable<FileSystemInfoEx> AlternativeEnumerateFileSystemInfos(string searchPattern = "*", SearchOption searchOption = SearchOption.TopDirectoryOnly)
    {
        InternalDirectoryInfo.Refresh();
        if (!InternalDirectoryInfo.Exists)
            yield break;

        var q = new Queue<DirectoryInfoEx>();
        q.Enqueue(this);

        while (q.TryDequeue(out var curDir))
        {
            curDir.Refresh();
            if (!curDir.Exists)
                continue;

            if (searchOption == SearchOption.AllDirectories)
                foreach (var subDir in curDir.GetDirectories())
                    q.Enqueue(subDir);

            foreach (var subDir in curDir.GetFileSystemInfos(searchPattern))
                yield return subDir;
        }
    }

    /// <summary>
    /// Moves a <see cref="DirectoryInfo"/> instance and its contents to a new path
    /// </summary>
    public void MoveTo(DirectoryInfoEx destDir)
    {
        InternalDirectoryInfo.MoveTo(destDir.FullName);
    }


    public Task MoveToAsync(string destDir, IProgress<AsyncCopyProgress>? progress = null, bool overwrite = false, CancellationToken cancellationToken = default) =>
        CopyToCoreAsync(new DirectoryInfoEx(destDir), progress, overwrite, true, cancellationToken);


    public Task MoveToAsync(DirectoryInfoEx destDir, IProgress<AsyncCopyProgress>? progress = null, bool overwrite = false, CancellationToken cancellationToken = default) =>
        CopyToCoreAsync(destDir, progress, overwrite, true, cancellationToken);

    public void CopyTo(DirectoryInfoEx destDir, bool overwriteFiles)
    {
        foreach (var file in AlternativeEnumerateFiles("*", SearchOption.AllDirectories))
        {
            var relPath = file.GetRelativePath(this);
            var destFile = destDir.ChildFile(relPath);
            file.CopyTo(destFile, overwriteFiles);
        }
    }

    public void CopyTo(string destDir, bool overwriteFiles) => CopyTo(new DirectoryInfoEx(destDir), overwriteFiles);

    public Task CopyToAsync(string destDir, IProgress<AsyncCopyProgress>? progress = null, bool overwrite = false, CancellationToken cancellationToken = default) =>
        CopyToCoreAsync(new DirectoryInfoEx(destDir), progress, overwrite, false, cancellationToken);


    public Task CopyToAsync(DirectoryInfoEx destDir, IProgress<AsyncCopyProgress>? progress = null, bool overwrite = false, CancellationToken cancellationToken = default) =>
        CopyToCoreAsync(destDir, progress, overwrite, false, cancellationToken);



    private async Task CopyToCoreAsync(DirectoryInfoEx destDir, IProgress<AsyncCopyProgress>? progress, bool overwrite, bool moveMode, CancellationToken cancellationToken)
    {
        var lst = new List<KeyValuePair<FileInfoEx, FileInfoEx>>();
        long totalBytes = 0;
        long totalBytesCopied = 0;

        await Task.Run(() =>
        {
            foreach (var file in AlternativeEnumerateFiles("*", SearchOption.AllDirectories))
            {
                cancellationToken.ThrowIfCancellationRequested();
                var relPath = file.GetRelativePath(this);
                var destFile = destDir.ChildFile(relPath);
                if (!overwrite && destFile.Exists)
                    throw new IOException($"File already exists: {destFile.FullName}");
                lst.Add(new KeyValuePair<FileInfoEx, FileInfoEx>(file, destFile));
                totalBytes += file.Length;
            }
        }, cancellationToken).ConfigureAwait(false);

        NonUIProgress<AsyncCopyProgress>? subProgress = null;
        if (progress != null)
        {
            var started = DateTime.Now;
            subProgress = new NonUIProgress<AsyncCopyProgress>(p => progress.Report(new AsyncCopyProgress(totalBytesCopied + p.BytesCopied, totalBytes, started)));
        }

        foreach (var file in lst)
        {
            await file.Key.CopyToAsync(file.Value, subProgress, overwrite, cancellationToken).ConfigureAwait(false);
            totalBytesCopied += file.Key.Length;
            if (moveMode)
                file.Key.TryDelete();
        }
    }
}