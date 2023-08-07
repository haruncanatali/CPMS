using Microsoft.AspNetCore.Http;

namespace CPMS.Application.Common.Interfaces;

public interface IFileService
{
    public string UploadPhoto(IFormFile file,string directory);
}