namespace TruePatch.Models
{
    public readonly struct PatchVersion
    {
        public string VersionName { get; }
        private string Version { get; }
        private string SubVersion { get; }

        public PatchVersion(string versionName, string version, string subVersion)
        {
            VersionName = versionName;
            Version = version;
            SubVersion = subVersion;
        }
    }
}