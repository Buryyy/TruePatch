namespace TruePatch.Models
{
    public class FilePatchProgress : IOperationProgress, Octodiff.Diagnostics.IProgressReporter
    {
        public int Percentage { get; private set; }
        public string ProgressInfo { get; private set; }

        internal FilePatchProgress(string filename)
        {
            Percentage = 0;
            ProgressInfo = ""; //TODO
        }

        public void ReportProgress(string operation, long currentPosition, long total)
        {
            Percentage = (int)((double)currentPosition / total * 100.0 + 0.5);
        }
    }
}