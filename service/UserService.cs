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
}
