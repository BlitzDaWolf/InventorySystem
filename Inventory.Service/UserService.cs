using Inventory.DAL.Service.Interface;
using Inventory.Data.Entities;
using Inventory.Service.Interfaces;

namespace Inventory.Service
{
    public class UserService : IUserService
    {
        readonly IUserDataServicve UserData;
        readonly IPasswordCheck passwordChecker;
        readonly ITokenGenerator tokenGenerator;

        public UserService(IUserDataServicve userData, IPasswordCheck passwordChecker, ITokenGenerator tokenGenerator)
        {
            this.UserData = userData;
            this.passwordChecker = passwordChecker;
            this.tokenGenerator = tokenGenerator;
        }

        public User GetUser(Guid ownerId)
        {
            return UserData.GetById(ownerId);
        }

        public string Login(string userName, string password)
        {
            User? user = UserData.GetByName(userName);
            if (user == null) throw new Exception("User not found");

            if (!passwordChecker.CheckPassword(user.Password, password)) throw new Exception("Password does not match");

            // Token generator
            return tokenGenerator.GenerateToken(user);
        }

        public bool Register(string userName, string password, string rePassword, string email)
        {
            if (UserData.UserExsist(userName)) throw new Exception("User already exsist");
            if (!passwordChecker.ValidPassword(password)) throw new Exception("Invalid password");
            if (password != rePassword) throw new Exception("Passwords do not match");

            UserData.Add(new User {
                Email = email,
                Password = password,
                Username = userName
            });

            return true;
        }
    }
}
