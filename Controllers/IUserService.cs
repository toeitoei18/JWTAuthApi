using JWTAuthApi.Models;

namespace JWTAuthApi.Controllers
{
    public interface IUserService
    {
        Task<(bool IUserRegistered, string Message)>RegisterNewUserAsync(UserRegistrationDto userRegistration);  
    }
}