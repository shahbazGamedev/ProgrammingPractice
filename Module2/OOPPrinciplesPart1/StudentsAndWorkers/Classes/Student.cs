namespace StudentsAndWorkers.Classes
{
    internal class Student : Human
    {
        internal Student(double grade, string firstName, string lastName)
        {
            this.Grade = grade;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        internal double Grade
        {
            get
            {
                return this.grade;
            }
            set
            {
                this.grade = value;
            }
        }

        private double grade;
    }
}
