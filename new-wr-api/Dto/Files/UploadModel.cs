using Microsoft.AspNetCore.Http;

namespace new_wr_api.Dto.Files
{
    public class UploadModel
    {
        public required string FilePath { get; set; }
        public required string FileName { get; set; }
        public required IFormFile File { get; set; }
    }
}
