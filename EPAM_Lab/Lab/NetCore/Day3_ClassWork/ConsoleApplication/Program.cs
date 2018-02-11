using System;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Xml.Schema;
using Attributes;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Type userclass = typeof (User);
            InstantiateUserAttribute[] instantiateUserAttributes =
                (InstantiateUserAttribute[]) Attribute.GetCustomAttributes(userclass, typeof (InstantiateUserAttribute));

            MatchParameterWithPropertyAttribute[] matchParameter = 
                (MatchParameterWithPropertyAttribute[]) Attribute.GetCustomAttributes(userclass.GetConstructors()[0], typeof(MatchParameterWithPropertyAttribute));

            var proper = userclass.GetProperty(matchParameter[0].Property);
            DefaultValueAttribute[] propertyAttributes =
                (DefaultValueAttribute[])Attribute.GetCustomAttributes(proper, typeof(DefaultValueAttribute));

            int defaultValue = (int) propertyAttributes[0].Value;

            User[] users = new User[3];
            for (int i = 0; i < 3; i++)
            {
                users[i] = new User(instantiateUserAttributes[i].Id);
                if (users[i].Id == 0) users[i].Id = defaultValue;
                users[i].FirstName = instantiateUserAttributes[i].FirstName;
                users[i].LastName = instantiateUserAttributes[i].LastName;
                Console.WriteLine(users[i].Id.ToString() + ' ' + users[i].FirstName + ' ' + users[i].LastName);

                try
                {
                    ValidateUser(users[i]);
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                
            }

            Console.ReadLine();
        }

        private static void ValidateUser(User user)
        {
            StringBuilder exception = new StringBuilder();

            Type userclass = typeof(User);
            var field = userclass.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)[0];
            IntValidatorAttribute[] fieldAttributes =
               (IntValidatorAttribute[])Attribute.GetCustomAttributes(field, typeof(IntValidatorAttribute));
            int left = fieldAttributes[0].Left;
            int right = fieldAttributes[0].Right;
            if (user.Id < left || user.Id > right) exception.AppendFormat("User Id ({2}) should be in range[{0},{1}] \n", left.ToString(), right.ToString(), user.Id.ToString());

            var firstNameProperty = userclass.GetProperty("FirstName");
            StringValidatorAttribute[] firstNamePropertyAttr =
               (StringValidatorAttribute[])Attribute.GetCustomAttributes(firstNameProperty, typeof(StringValidatorAttribute));
            int value1 = firstNamePropertyAttr[0].Value;
            if (user.FirstName.Length > value1) exception.AppendFormat("First Name ({1}) length should be not greater than {0} \n", value1, user.FirstName);

            var lastNameProperty = userclass.GetProperty("LastName");
            StringValidatorAttribute[] lastNamePropertyAttr =
               (StringValidatorAttribute[])Attribute.GetCustomAttributes(lastNameProperty, typeof(StringValidatorAttribute));
            int value2 = lastNamePropertyAttr[0].Value;
            if (user.LastName.Length > value2) exception.AppendFormat("Last Name ({1}) length should be not greater than {0} \n", value2, user.LastName);

            if (exception.Length != 0) throw new ArgumentException(exception.ToString());
        }
    }
}
