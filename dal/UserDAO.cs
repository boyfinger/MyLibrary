using Microsoft.EntityFrameworkCore;
using model;

namespace dal
{
    public class UserDAO
    {
        public static List<User> getAllUsers()
        {
            var db = new LibraryContext();
            return db.Users.Where(u => u.IsAdmin == false).ToList();
        }
        public static User getUserByEmail(String email)
        {
            var db = new LibraryContext();
            return db.Users.FirstOrDefault(user => user.Email == email);
        }

        public static User adminAccount()
        {
            var db = new LibraryContext();
            return db.adminAccount();
        }

        public static void insertUser(User user)
        {
            try
            {
                var db = new LibraryContext();
                db.Users.Add(user);
                db.SaveChanges();
            }
            catch
            {
                throw new Exception("Insert user failed!");
            }
        }

        public static void updateUser(User user)
        {
            try
            {
                var db = new LibraryContext();
                db.Entry<User>(user).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                throw new Exception("Update user failed!");
            }
        }

        public static User getUserById(int userId)
        {
            var db = new LibraryContext();
            return db.Users.FirstOrDefault(user => user.UserId == userId);
        }

        public static void removeUser(User user)
        {
            try
            {
                var db = new LibraryContext();
                db.Users.Remove(user);
                db.SaveChanges();
            }
            catch
            {
                throw new Exception("Remove user failed!");
            }
        }
    }
}
