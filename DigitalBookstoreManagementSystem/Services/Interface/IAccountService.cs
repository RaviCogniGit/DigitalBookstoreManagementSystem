using DigitalBookstoreManagementSystem.DTO;

namespace DigitalBookstoreManagementSystem.Services.Interface
{
    public interface IAccountService
    {
        Task<bool> RegisterUser(RegisterUserDTO userdto);

        Task<string> AuthenticateUser(LoginUserDTO logindto); // String because jwt token returned after login

    }
}
