using System;
using System.Collections.Generic;
using TruePatch.Core;

namespace TruePatch.Models
{
    public class PatchContext
    {
        public IList<Uri> FileUris { get; set; }

        public PatchVersion Version { get; set; }

        public PatchMethod PatchMethod { get; set; }

        public bool ParallelPatch { get; set; }

        public string InstallPath { get; set; }
    }
}