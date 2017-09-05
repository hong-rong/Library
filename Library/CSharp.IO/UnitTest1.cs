using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace CSharp.IO
{
    public enum Gender
    {
        Male = 1,
        Female = 2
    }

    public class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public Gender Gender { get; set; }

        public User()
        { }

        public User(string firstName, string lastName, string id, string department, Gender gender)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Department = department;
            Gender = gender;
        }
    }

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IList<User> users = new List<User>();
            users.Add(new User("Vladimir", "Putin", "122", "Government of Russia", Gender.Male));
            users.Add(new User("Barack", "Obama", "123", "Government of USA", Gender.Male));
            users.Add(new User("Stephen", "Harper", "124", "Government of Canada", Gender.Male));
            users.Add(new User("Jean", "Charest", "125", "Government of Quebec", Gender.Male));
            users.Add(new User("David", "Cameron", "126", "Government of United Kingdom", Gender.Male));
            users.Add(new User("Angela", "Merkel", "127", "Government of Germany", Gender.Female));
            users.Add(new User("Nikolas", "Sarkozy", "128", "Government of France", Gender.Male));
            users.Add(new User("Silvio", "Berlusconi", "129", "Government of Italy", Gender.Male));
            users.Add(new User("Yoshihiko", "Noda", "130", "Government of Japan", Gender.Male));

            StringBuilder sb = new StringBuilder();
            foreach (var user in users)
            {
                sb.AppendLine(string.Format("{0};{1};{2};{3};{4}",
                    user.Id, user.FirstName, user.LastName, user.Department, user.Gender));
            }
            File.WriteAllText(@"C:\GitHub\user.txt", sb.ToString());
        }
    }
}
