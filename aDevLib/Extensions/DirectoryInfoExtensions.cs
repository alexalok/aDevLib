using System.IO;

namespace aDevLib.Extensions
{
    public static class DirectoryInfoExtensions
    {
        public static void ForceDelete(this FileSystemInfo fileSystemInfo)
        {
            if (fileSystemInfo is DirectoryInfo directoryInfo)
                foreach (var childInfo in directoryInfo.GetFileSystemInfos())
                    childInfo.ForceDelete();

            fileSystemInfo.Attributes = FileAttributes.Normal;
            fileSystemInfo.Delete();
        }
    }
}