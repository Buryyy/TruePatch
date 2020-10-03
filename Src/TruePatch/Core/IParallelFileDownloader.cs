using TruePatch.Models;

namespace TruePatch.Core
{
    internal interface IParallelFileDownloader
    {
        void EnqueueFile(DownloadFile file);
    }
}