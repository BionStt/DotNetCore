using DotNetCore.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DotNetCore.Objects
{
    public static class BinaryFileExtensions
    {
        public static async Task<IEnumerable<BinaryFile>> SaveAsync(this IEnumerable<BinaryFile> files, string directory)
        {
            if (string.IsNullOrWhiteSpace(directory)) { return null; }

            foreach (var file in files)
            {
                await file.SaveAsync(directory).ConfigureAwait(false);
            }

            return files;
        }
    }
}
