namespace TruePatch.Models
{
    internal struct DownloadFile
    {
        public string Url { get; }

        public string TargetPath { get; }

        public DownloadFile(string url, string pathToSave)
        {
            Url = url;
            TargetPath = pathToSave;
        }
    }
}