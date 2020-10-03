using System;
using System.Collections.Generic;
using TruePatch.Models;

namespace TruePatch.Core
{
    public class PatchBuilder : IPatchBuilder
    {
        private readonly PatchContext _patchContext;

        public PatchBuilder() => _patchContext = new PatchContext();

        public IPatchBuilder WithDownloadUrls(IList<Uri> uris)
        {
            _patchContext.FileUris = uris;
            return this;
        }

        public IPatchBuilder WithVersion(PatchVersion patchVersion)
        {
            _patchContext.Version = patchVersion;
            return this;
        }

        public IPatchBuilder WithPatchMethod(PatchMethod method)
        {
            _patchContext.PatchMethod = method;
            return this;
        }

        public IPatchBuilder WithParallelDownload(bool allowParallelPatch)
        {
            _patchContext.ParallelPatch = allowParallelPatch;
            return this;
        }

        public IPatchBuilder WithPatchTargetFolder(string installPath)
        {
            _patchContext.InstallPath = installPath;
            return this;
        }
    }
}