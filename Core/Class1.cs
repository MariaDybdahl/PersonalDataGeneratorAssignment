namespace Core
{
    public class Person
    {
        public int Id { get; set; }

        public string Cpr { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Gender { get; set; } = "";
        public DateTime BirthDate { get; set; }
        public List<string> Address { get; set; } = new();
        public string PhoneNumber { get; set; } = "";


    }
}
