using System.Collections.Generic;

namespace ViewsTask.Models
{
    public class UserStorage
    {
        public static List<User> Users;

        static UserStorage()
        {
            Users = new List<User>();

            Users.Add(new User
            {
                Name = "Luke Skywalker",
                UserFraction = Fraction.Light
            });

            Users.Add(new User()
            {
                Name = "Dark Vaider",
                UserFraction = Fraction.Dark
            });
        }

        public static void Add(User user)
        {
            Users.Add(user);
        }

        public static List<User> GetUsers()
        {
            return Users;
        }
    }
}