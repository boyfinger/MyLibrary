using bo.Interface;
using dal;
using model;

namespace bo
{
    public class UserManagement : IUserManagement
    {
        public User getUserByEmail(string email) => UserDAO.getUserByEmail(email);
    }
}
