namespace StudentsAndWorkers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using StudentsAndWorkers.Classes;

    public class EntryPoint
    {
        public static void Main()
        {
            List<Student> students = new List<Student>();

            students.Add(new Student(2.45d, "Gosho", "Goshev"));
            students.Add(new Student(5.89d, "Gosho", "Goshev"));
            students.Add(new Student(4.45d, "Gosho", "Goshev"));
            students.Add(new Student(3.50d, "Gosho", "Goshev"));
            students.Add(new Student(2.00d, "Gosho", "Goshev"));
            students.Add(new Student(4.40d, "Gosho", "Goshev"));
            students.Add(new Student(5.60d, "Gosho", "Goshev"));
            students.Add(new Student(4.45d, "Gosho", "Goshev"));
            students.Add(new Student(5.60d, "Gosho", "Goshev"));
            students.Add(new Student(3.76d, "Gosho", "Goshev"));
            students.Add(new Student(2.89d, "Gosho", "Goshev"));

            var sortedStudentsByGrade = students.OrderBy(s => s.Grade).ToList();
            foreach (var student in sortedStudentsByGrade)
            {
                Console.WriteLine("{0} {1}: {2}", student.FirstName, student.LastName, student.Grade);
            }

            Console.WriteLine();

            List<Worker> workers = new List<Worker>();
            workers.Add(new Worker("Pesho", "Peshev", 125.50m, 8));
            workers.Add(new Worker("Pesho", "Peshev", 60.20m, 12));
            workers.Add(new Worker("Pesho", "Peshev", 150.50m, 12));
            workers.Add(new Worker("Pesho", "Peshev", 12.46m, 6));
            workers.Add(new Worker("Pesho", "Peshev", 345.56m, 8));
            workers.Add(new Worker("Pesho", "Peshev", 1000m, 8));
            workers.Add(new Worker("Pesho", "Peshev", 70.00m, 12));
            workers.Add(new Worker("Pesho", "Peshev", 700.80m, 8));
            workers.Add(new Worker("Pesho", "Peshev", 50.00m, 10));
            workers.Add(new Worker("Pesho", "Peshev", 500.50m, 12));

            var sortedWorkersByMoneyPerHour = workers.OrderByDescending(w => w.MoneyPerHour()).ToList();
            foreach (var worker in sortedWorkersByMoneyPerHour)
            {
                Console.WriteLine("{0} {1}: ${2}", worker.FirstName, worker.LastName, decimal.Round(worker.MoneyPerHour(), 2));
            }
        }
    }
}
