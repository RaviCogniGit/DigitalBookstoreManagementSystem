using DigitalBookstoreManagementSystem.DTO;

namespace DigitalBookstoreManagementSystem.Services.Interface
{
    public interface IRegisterService
    {
        Task<bool> RegisterUser(RegisterUserDTO userdto);
    }
}
