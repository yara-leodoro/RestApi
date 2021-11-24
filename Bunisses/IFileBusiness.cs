using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using RESTApi.Data.VO;

namespace RESTApi.Bunisses
{
    public interface IFileBusiness
    {
        public byte[] GetFile(string fileName);
        public Task<FileDetailVO> saveFileToDisk(IFormFile file);
        public TaskCompletionSource<List<FileDetailVO>> SaveFilesToDisk(IList<IFormFile> file);
        
    }
}