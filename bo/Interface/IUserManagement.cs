using model;

namespace bo.Interface
{
    public interface IUserManagement
    {
        User getUserByEmail(String email);
        User getAdmin();
        List<User> getAllUsers();
        User insertUser(User user);
        User updateUser(User user);
        User removeUser(User user);
    }
}
