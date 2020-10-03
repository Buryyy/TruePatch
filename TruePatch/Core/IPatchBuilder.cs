using System;
using System.Collections.Generic;
using TruePatch.Models;

namespace TruePatch.Core
{
    public interface IPatchBuilder
    {
        /// <summary>
        /// List of file uris to download.
        /// </summary>
        /// <param name="uris"></param>
        /// <returns></returns>
        IPatchBuilder WithDownloadUrls(IList<Uri> uris);

        /// <summary>
        /// Add a strongly typed patch version.
        /// </summary>
        /// <param name="patchVersion"></param>
        /// <returns></returns>
        IPatchBuilder WithVersion(PatchVersion patchVersion);

        /// <summary>
        /// Specify a target patch method. Defaults to <see cref="PatchMethod.Delta"/>
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        IPatchBuilder WithPatchMethod(PatchMethod method);

        /// <summary>
        /// Allows multi downloading and patch applying in parallel.
        /// </summary>
        /// <param name="allowed"></param>
        /// <returns></returns>
        IPatchBuilder WithParallelDownload(bool allowParallelPatch);

        /// <summary>
        /// Supply a folder path where the files should be patched. If none, defaults to executing path with folder name "PachInstall"
        /// </summary>
        /// <param name="installPath"></param>
        /// <returns></returns>
        IPatchBuilder WithPatchTargetFolder(string installPath);
    }
}