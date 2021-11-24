using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using RESTApi.Data.VO;

namespace RESTApi.Bunisses.Implementations
{
    public class FileBusinessImplementation : IFileBusiness
    {

        private readonly string _basePath;
        private readonly IHttpContextAccessor _context;
        public FileBusinessImplementation(IHttpContextAccessor context)
        {
            _context = context;
            _basePath = Directory.GetCurrentDirectory() + "//UploadDir//";
        }

        public byte[] GetFile(string fileName)
        {
            throw new System.NotImplementedException();
        }
        public async Task<FileDetailVO> saveFileToDisk(IFormFile file)
        {
            FileDetailVO fileDetail = new FileDetailVO();

            var fileType = Path.GetExtension(file.FileName);
            var baseUrl = _context.HttpContext.Request.Host;
            if(fileType.ToLower() == ".pdf" || fileType.ToLower() == ".jpg" || fileType.ToLower() == ".png" || fileType.ToLower() == ".jpeg")
            {
                var docName = Path.GetFileName(file.FileName);

                if(file != null && file.Length > 0)
                {
                    var destination = Path.Combine(_basePath, "", docName);
                    fileDetail.doucumentName = docName;
                    fileDetail.doucumentType = fileType;
                    fileDetail.doucumentUrl = Path.Combine(baseUrl + "/api/file/v1" + fileDetail.doucumentName);

                    using var stream = new FileStream(destination, FileMode.Create);

                    await file.CopyToAsync(stream);
                }
            }
            return fileDetail;
        }

        public TaskCompletionSource<List<FileDetailVO>> SaveFilesToDisk(IList<IFormFile> file)
        {
            throw new System.NotImplementedException();
        }

    }
}