namespace ESH.CLI.Extensions
{
    public static class FileSizeExtensions
    {
        private static string[] sizes = {"B", "KB", "MB", "GB", "TB"};

        public static string ToSizeString(this long fileSize)
        {
            int order = 0;
            while (fileSize >= 1024 && order < sizes.Length - 1)
            {
                order++;
                fileSize = fileSize / 1024;
            }

            return string.Format("{0:0.##} {1}", fileSize, sizes[order]);
        }
    }
}