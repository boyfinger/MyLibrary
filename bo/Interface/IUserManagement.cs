using model;

namespace bo.Interface
{
    public interface IUserManagement
    {
        User getUserByEmail(String email);
    }
}
