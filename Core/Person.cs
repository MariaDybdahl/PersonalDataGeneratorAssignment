namespace Core
{
    public class Person
    {
        public Person()
        {
        }

        public string CPR { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Gender { get; set; } = "";
        public DateTime BirthDate { get; set; }
        public Address Address { get; set; }
        public string PhoneNumber { get; set; } = "";

        public Person(string cPR, string firstName, string lastName, string gender, DateTime birthDate, Address address, string phoneNumber)
        {
            CPR = cPR;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            BirthDate = birthDate;
            Address = address;
            PhoneNumber = phoneNumber;
        }
    }
}
