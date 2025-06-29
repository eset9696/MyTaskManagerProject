using MyTaskManagerProject.Models.Domain;

namespace MyTaskManagerProject.Services
{
    public interface IUserService
    {
        User? GetUserById(long id);
        
        void CreateUser(User user);

        void EditUser(User user);

        void DeleteUser(long id);
    }
}
