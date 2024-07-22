using bo.Interface;
using dal;
using model;

namespace bo
{
    public class UserManagement : IUserManagement
    {
        public User getUserByEmail(string email) => UserDAO.getUserByEmail(email);

        public User getAdmin() => UserDAO.adminAccount();

        public List<User> getAllUsers() => UserDAO.getAllUsers();

        public User insertUser(User user)
        {
            User u = UserDAO.getUserByEmail(user.Email);
            if (u != null)
            {
                throw new Exception("Email has already been registered!");
            }
            else
            {
                user.IsAdmin = false;
                UserDAO.insertUser(user);
                return user;
            }
        }

        public User updateUser(User user)
        {
            User u = UserDAO.getUserById(user.UserId);
            if (u == null)
            {
                throw new Exception("User not found!");
            }
            else
            {
                user.IsAdmin = false;
                UserDAO.updateUser(user);
                return user;
            }
        }

        public User removeUser(User user)
        {
            User u = UserDAO.getUserById(user.UserId);
            if (u == null)
            {
                throw new Exception("User not found!");
            }
            else
            {
                UserDAO.removeUser(u);
                return u;
            }
        }
    }
}
