using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ControllersAdminBaseUser.Models;

namespace ControllersAdminBaseUser.Infrastructure
{
    public class UserStorage
    {
        public static List<UserViewModel> Users = new List<UserViewModel>();

        public static void Add(UserViewModel user)
        {
            Users.Add(user);
        }

        public static async Task AddAsync(UserViewModel user)
        {
            await Task.Delay(2000);
            Add(user);
        }

        public static List<UserViewModel> GetUsers()
        {
            Thread.Sleep(2000);
            return Users;
        }

        public static void Clear()
        {
            Users.Clear();
        }
    }
}