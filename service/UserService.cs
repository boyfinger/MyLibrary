using bo;
using bo.Interface;
using model;
using service.Interfaces;

namespace service
{
    public class UserService : IUserService
    {
        private readonly IUserManagement iUserManagement;

        public UserService()
        {
            iUserManagement = new UserManagement();
        }

        public User login(User user)
        {
            User admin = iUserManagement.getAdmin();

            if (admin != null && user.Email == admin.Email)
            {
                if (user.Password != admin.Password) 
                {
                    throw new Exception("Incorrect password!");
                }
                user.IsAdmin = true;
                return user;
            }
            else
            {
                User u = iUserManagement.getUserByEmail(user.Email);
                if (u == null)
                {
                    throw new Exception("Email not found!");
                }
                if (u.Password != user.Password)
                {
                    throw new Exception("Incorrect password!");
                }
                return u;
            }
        }

        public User getAdminAccount() => iUserManagement.getAdmin();

        public List<User> getAllUsers() => iUserManagement.getAllUsers();

        public User insertUser(User user) => iUserManagement.insertUser(user);

        public User updateUser(User user) => iUserManagement.updateUser(user);

        public User removeUser(User user) => iUserManagement.removeUser(user);
    }
}
