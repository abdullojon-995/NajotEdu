using Microsoft.AspNetCore.Http;
using NajotTalim.Application.Models;

namespace NajotTalim.Application.Abstractions
{
    public interface IProfileService
    {
        Task SetPhoto(IFormFile formFile);
        Task<ProfileViewModel> GetProfile();
    }
}
