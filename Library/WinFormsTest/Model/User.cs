namespace WinFormsTest.Model
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
            FirstName = firstName;
            LastName = lastName;
            Department = department;
            Gender = gender;
        }
    }
}
