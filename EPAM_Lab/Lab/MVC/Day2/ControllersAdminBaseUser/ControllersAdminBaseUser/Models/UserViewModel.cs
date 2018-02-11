namespace ControllersAdminBaseUser.Models
{
    public class UserViewModel
    {
        private static int id;

        public UserViewModel()
        {
            id++;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Id
        {
            get { return id; }
            private set { id = value; }
        }
    }
}