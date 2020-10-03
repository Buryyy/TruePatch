using System.IO;
using System.Threading;

namespace TruePatch.Utils
{
    public class TruePatchUtils
    {
        public static void MoveFile(string fromAbsolutePath, string toAbsolutePath)
        {
            if (File.Exists(toAbsolutePath))
            {
                CopyFile(fromAbsolutePath, toAbsolutePath);
                File.Delete(fromAbsolutePath);
            }
            else
            {
                Directory.CreateDirectory(Path.GetDirectoryName(toAbsolutePath));
                File.Move(fromAbsolutePath, toAbsolutePath);
            }
        }

        public static void CopyFile(string from, string to)
        {
            // Replacing a file that is in use can throw IOException; in such cases,
            // waiting for a short time might resolve the issue
            for (int i = 8; i >= 0; i--)
            {
                if (i > 0)
                {
                    try
                    {
                        File.Copy(from, to, true);
                        break;
                    }
                    catch (IOException)
                    {
                        Thread.Sleep(500);
                    }
                }
                else
                    File.Copy(from, to, true);
            }
        }
    }
}