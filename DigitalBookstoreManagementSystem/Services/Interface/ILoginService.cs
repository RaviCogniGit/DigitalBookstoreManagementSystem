using DigitalBookstoreManagementSystem.DTO;

namespace DigitalBookstoreManagementSystem.Services.Interface
{
    public interface ILoginService
    {
        Task<string> AuthenticateUser(LoginUserDTO logindto); // String because jwt token returned after login
    }
}
