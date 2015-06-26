namespace StudentQueries
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using StudentQueries.Libs;

    public class Test
    {
        public static void Main()
        {
            List<Student> students = new List<Student>();
            FillInformation(students);

            var firstNameBeforeLast = from student in students
                                      where string.Compare(student.FirstName, student.LastName, true) < 0
                                      select student;
            PrintResult(firstNameBeforeLast.ToList());

            var ageBetween = from student in students
                             where (student.Age >= 18 && student.Age <= 24)
                             select student;
            PrintResult(ageBetween.ToList());

            var sortedByFirstName = students.OrderBy(s => s.FirstName).ToList();
            PrintResult(sortedByFirstName);

            var sortedByLastName = students.OrderBy(s => s.LastName).ToList();
            PrintResult(sortedByLastName);

            var secondGroupSortedByFirstName = students.Where(s => s.GroupNumber == "2").OrderBy(s => s.FirstName).ToList();
            PrintResult(secondGroupSortedByFirstName);

            var emailsInAbv = students.Where(s => s.Email.Contains("@abv.bg")).ToList();
            PrintResult(emailsInAbv);

            var phonesInSofia = students.Where(s => s.Phone.StartsWith("02")).ToList();
            PrintResult(phonesInSofia);

            var hasExcellentMark = students.Where(s => s.Marks.Contains(6.00)).ToList();
            foreach (var student in hasExcellentMark)
            {
                var s = new { Name = student.FirstName, Marks = student.Marks };
                Console.Write(s.Name + ", ");
                foreach (var m in s.Marks)
	            {
                    Console.Write(m + " ");
	            }
                Console.WriteLine();
            }

            Console.WriteLine(new string('-', 30));

            var twoMarks = from student in students
                           where (student.Marks.Count(m => m == 2) == 2)
                           select student;
            PrintResult(twoMarks.ToList());
        }

        private static void FillInformation(List<Student> students)
        {
            students.Add(new Student
            {
                FirstName = "Yordan",
                LastName = "Petrov",
                Age = 12,
                FacultyNumber = "33231234",
                Phone = "0883452345",
                Email = "y.petrov@abv.bg",
                Marks = new List<double> { 2, 4.5, 2, 5, 6, 3.50 },
                GroupNumber = "2"
            });

            students.Add(new Student
            {
                FirstName = "Gosho",
                LastName = "Ivanov",
                Age = 15,
                FacultyNumber = "23231935",
                Phone = "0893457312",
                Email = "goshko_qkiq@gmail.com",
                Marks = new List<double> { 2, 2, 2, 2, 2, 2 },
                GroupNumber = "2"
            });

            students.Add(new Student
            {
                FirstName = "Maria",
                LastName = "Petkova",
                Age = 18,
                FacultyNumber = "95847592",
                Phone = "0234512",
                Email = "maria_petkova1@live.com",
                Marks = new List<double> { 5, 4.5, 6, 5, 6, 5.50 },
                GroupNumber = "20"
            });

            students.Add(new Student
            {
                FirstName = "Ivelin",
                LastName = "Angelov",
                Age = 16,
                FacultyNumber = "34672309",
                Phone = "0896542156",
                Email = "angelov16@abv.bg",
                Marks = new List<double> { 2.90, 4.80, 3.40, 5, 6, 5 },
                GroupNumber = "5"
            });

            students.Add(new Student
            {
                FirstName = "Svilen",
                LastName = "Shopov",
                Age = 17,
                FacultyNumber = "47584758",
                Phone = "0886987531",
                Email = "sv_sh10@abv.bg",
                Marks = new List<double> { 5, 5, 2.50, 5.60, 6.00, 4.00 },
                GroupNumber = "1"
            });

            students.Add(new Student
            {
                FirstName = "Boris",
                LastName = "Minev",
                Age = 22,
                FacultyNumber = "47856547",
                Phone = "0284790",
                Email = "minev7@abv.bg",
                Marks = new List<double> { 3, 2, 3, 3, 2, 3 },
                GroupNumber = "3"
            });
        }

        private static void PrintResult(List<Student> result)
        {
            foreach (var student in result)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName);
            }

            Console.WriteLine(new string('-', 30));
        }
    }
}
