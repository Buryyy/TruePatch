using TruePatch.Models;

namespace TruePatch.Core
{
    internal interface IParallelDownloader
    {
        void EnqueueFile(DownloadFile file);
    }
}