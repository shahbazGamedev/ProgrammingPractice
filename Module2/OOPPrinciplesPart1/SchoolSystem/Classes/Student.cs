namespace SchoolSystem
{
    public class Student : Person
    {
        public Student(string firstName, string lastName, int uniqueNumber) 
            : base(firstName, lastName)
        {
            this.UniqueNumber = uniqueNumber;
        }

        public int UniqueNumber { get; set; }
    }
}