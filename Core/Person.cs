namespace Core
{
    public class Person
    {
        public Person()
        {
  
        }

        private readonly Address _address;
        public string CPR { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Gender { get; set; } = "";
        public DateTime BirthDate { get; set; }
        public Address Address { get; set; }
        public string PhoneNumber { get; set; } = "";

        public Person(string cPR, string firstName, string lastName, string gender, DateTime birthDate, string phoneNumber, Address address)
        {
            CPR = cPR;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        public Person SetRandomPerson()
        {
            var address = new Address().GetRandomAddress();

            return new Person(
                "1234567890",
                "Anna",
                "Jensen",
                "female",
                new DateTime(1998, 4, 12),
                "28123456",
                address
            );
        }

    }
}
