namespace SchoolSystem
{
    public abstract class Person
    {
        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = LastName;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}