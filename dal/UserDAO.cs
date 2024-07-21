using model;

namespace dal
{
    public class UserDAO
    {
        private static List<User> getAllUsers()
        {
            var db = new LibraryContext();
            return db.Users.ToList();
        }
        public static User getUserByEmail(String email)
        {
            var db = new LibraryContext();
            return db.Users.FirstOrDefault(user => user.Email == email);
        }
    }
}
