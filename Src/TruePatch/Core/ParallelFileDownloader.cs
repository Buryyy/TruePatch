using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Timers;
using TruePatch.Models;

namespace TruePatch.Core
{
    internal class ParallelFileDownloader : IParallelDownloader
    {
        private const int MaxParallelization = 5;

        private readonly PatchContext _patchContext;
        private readonly Timer _downloadTimer;

        private readonly IList<Task> _downloadTasks;
        private readonly ConcurrentQueue<DownloadFile> _downloadQueue;

        public ParallelFileDownloader(PatchContext patchContext)
        {
            _patchContext = patchContext;
            _downloadQueue = new ConcurrentQueue<DownloadFile>();
            _downloadTasks = new List<Task>();
            _downloadTimer = new Timer()
            {
                Interval = 1000
            };
            _downloadTimer.Elapsed += OnDownloadTimerElapsed;
            _downloadTimer.Start();
        }

        public void EnqueueFile(DownloadFile file) => _downloadQueue.Enqueue(file);

        private void OnDownloadTimerElapsed(object sender, ElapsedEventArgs e) => ExecuteDownload();

        private void ExecuteDownload()
        {
            lock (_downloadTasks)
            {
                if (_downloadTasks.Count < MaxParallelization && _downloadQueue.Count > 0)
                {
                    if (_downloadQueue.TryDequeue(out var fileToDownload))
                    {
                        var task = new Task(() =>
                        {
                            var client = new WebClient();
                            client.DownloadFile(fileToDownload.Url, fileToDownload.TargetPath);
                        }, TaskCreationOptions.LongRunning);

                        task.ContinueWith(DownloadOverCallback, TaskContinuationOptions.None);

                        _downloadTasks.Add(task);
                        task.Start();
                    }
                }
            }
        }

        private void DownloadOverCallback(Task downloadingTask)
        {
            lock (_downloadTasks)
            {
                _downloadTasks.Remove(downloadingTask);
            }
        }
    }
}