using model;

namespace service.Interfaces
{
    public interface IUserService
    {
        User login (User user);
        User getAdminAccount();
        List<User> getAllUsers();
        User insertUser(User user);
        User updateUser(User user);
        User removeUser(User user);
    }
}
