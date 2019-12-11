using Microsoft.AspNetCore.StaticFiles;
using System.Net.Mime;

namespace DotNetCore.AspNetCore
{
    public class FileService : IFileService
    {
        public string GetContentType(string path)
        {
            new FileExtensionContentTypeProvider().TryGetContentType(path, out var contentType);

            if (string.IsNullOrEmpty(contentType))
            {
                contentType = MediaTypeNames.Application.Octet;
            }

            return contentType;
        }
    }
}
