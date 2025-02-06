using System.Security.Cryptography;
using JWTAuthApi.Models;


namespace JWTAuthApi.Controllers
{
    public class UserService : IUserService
    {
        // private readonly ToeiContext _DbContext;
        // public UserService(ToeiContext DbContext)
        // {
        //     _DbContext = DbContext;
        // }
        // public Task<(bool IsUserRegistered, string Message)>RegisterNewUserAsync(UserRegistrationDto userRegistration)     
        // {
        //     // throw new NotFiniteNumberException();
        //     var IsUserRegistered =
        // }
        private readonly ToeiContext _DbContext;
        public UserService(ToeiContext DbContext)
        {
            _DbContext = DbContext;
        }
        private User FromUserRegistrationModelToUserMode(UserRegistrationDto userRegistration)
        {
            return new User
            {
                Email = userRegistration.Email,
                FirstName = userRegistration.FirstName,
                LastName = userRegistration.LastName,
                Password = userRegistration.Password,
            };
        }
        private string HashPassword(string plainPassword)
        {
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            var new Rfc2898DeriveBytes(plainPassword, salt, 1000, HashAlgorithmName.SHA1);
        }
        public async Task<(bool IsUserRegistered, string Message)> RegisterNewUserAsync(UserRegistrationDto userRegistration)
        {
            // throw new NotImplementedException();
            var isUserExist = _DbContext.Users.Any(_ => _.Email.ToLower() == userRegistration.Email.ToLower());
            if (isUserExist)
            {
                return (false, "Email Address Already Registred");
            }

            var newUser = FromUserRegistrationModelToUserMode(userRegistration);
        }
    }
}