using System;

namespace ViewsTask.Models
{
    public class User
    {
        static User()
        {
            counter = 0;
        }
        public User()
        {
            UserFraction = Fraction.Light;
            counter++;
            Id = counter;
        }

        private static int counter;
        public Fraction UserFraction { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }

        public void ChangeFraction()
        {
            UserFraction = UserFraction == Fraction.Dark ? Fraction.Light : Fraction.Dark;
        }
    }
}