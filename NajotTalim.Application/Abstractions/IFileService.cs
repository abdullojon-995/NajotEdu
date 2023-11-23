using Microsoft.AspNetCore.Http;

namespace NajotTalim.Application.Abstractions
{
    public interface IFileService
    {
        Task<string> Upload(IFormFile formFile);
    }
}
