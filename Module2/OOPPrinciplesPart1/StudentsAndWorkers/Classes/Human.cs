namespace StudentsAndWorkers.Classes
{
    internal abstract class Human
    {
        internal string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                this.firstName = value;
            }
        }

        internal string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                this.lastName = value;
            }
        }

        private string firstName;
        private string lastName;
    }
}
