namespace StudentsAndWorkers.Classes
{
    internal class Worker : Human
    {
        internal Worker(string firstName, string lastName, decimal weekSalary, int workHoursPerDay)  
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        internal decimal WeekSalary { private get; set; }
        internal int WorkHoursPerDay { private get; set; }

        internal decimal MoneyPerHour()
        {
            return this.WeekSalary / this.WorkHoursPerDay;
        }
    }
}
