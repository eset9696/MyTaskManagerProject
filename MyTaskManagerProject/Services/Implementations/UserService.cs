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



        public void Register(string login, string password, string email, string phoneNumber)
        {
            User user = new User()
            {
                Login = login,
                Password = password,
                Email = email,
                PhoneNumber = phoneNumber
            };
            _database.Users.Add(user);
            _database.SaveChanges();
        }

        public User? Authorize(string login, string password)
        {
            return _database.Users.Where(user => user.Login == login && user.Password == password).FirstOrDefault();
        }

        public User? GetUserById(long id)
        {
            return _database.Users.FirstOrDefault(user => user.Id ==id);
        }
    }
}
