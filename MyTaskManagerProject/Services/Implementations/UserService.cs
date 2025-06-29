using MyTaskManagerProject.Data;
using MyTaskManagerProject.Models.Domain;

namespace MyTaskManagerProject.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _database;

        public UserService(ApplicationDbContext database)
        {
            _database = database;
        }
        public void CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(long id)
        {
            throw new NotImplementedException();
        }

        public void EditUser(User user)
        {
            throw new NotImplementedException();
        }

        public User? GetUserById(long id)
        {
            return _database.Users.FirstOrDefault(user => user.Id ==id);
        }
    }
}
