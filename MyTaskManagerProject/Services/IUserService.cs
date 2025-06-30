using MyTaskManagerProject.Models.Domain;

namespace MyTaskManagerProject.Services
{
    public interface IUserService
    {
        User? GetUserById(long id);
        
        void Register(string login, string password, string email, string phoneNumber);

        User? Authorize(string login, string password);
    }
}
