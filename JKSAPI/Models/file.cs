using Microsoft.AspNetCore.Http;

namespace JKSAPI
{
    public class FileModel
    {
        public string FileName { get; set; }
        public IFormFile FormFile { get; set; }
    }
}