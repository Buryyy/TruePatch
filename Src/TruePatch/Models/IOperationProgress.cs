namespace TruePatch.Models
{
    public interface IOperationProgress
    {
        int Percentage { get; }
        string ProgressInfo { get; }
    }
}