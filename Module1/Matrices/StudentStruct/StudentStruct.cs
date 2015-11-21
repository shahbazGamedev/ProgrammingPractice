// Make a struct of students each having an ID, Name, Age, Gender and Score out of 100. 
// Create an Array of 10 students and sort them by:
// ID, Name, Name (reverse), Age, Score, Name Length and (first by Gender and then by Name).

using System;
using System.Collections.Generic;
using System.IO;

class StudentStruct
{
    struct Student
    {
        public string ID;
        public string name;
        public int age;
        public char gender;
        public int score;
    }

    static void Main()
    {
        Student[] thirdGrade = new Student[10];

        string[] data = File.ReadAllLines("StudentsInfo.txt");

        int currentStudent = 0;
        int currentLine = 0;
        while (currentLine < data.Length)
        {
            thirdGrade[currentStudent].ID = data[currentLine];
            currentLine++;

            thirdGrade[currentStudent].name = data[currentLine];
            currentLine++;

            thirdGrade[currentStudent].age = int.Parse(data[currentLine]);
            currentLine++;

            thirdGrade[currentStudent].gender = char.Parse(data[currentLine]);
            currentLine++;

            thirdGrade[currentStudent].score = int.Parse(data[currentLine]);
            currentLine++;

            currentStudent++;
        }

        Console.WriteLine("ORIGINAL ORDER");
        PrintStudentData(thirdGrade);

        Console.WriteLine("ID SORT");
        Array.Sort(thirdGrade, (x, y) => x.ID.CompareTo(y.ID));
        PrintStudentData(thirdGrade);

        Console.WriteLine("NAME SORT");
        Array.Sort(thirdGrade, (x, y) => x.name.CompareTo(y.name));
        PrintStudentData(thirdGrade);

        Console.WriteLine("NAME REVERSE SORT");
        Array.Sort(thirdGrade, (x, y) => y.name.CompareTo(x.name));
        PrintStudentData(thirdGrade);

        Console.WriteLine("AGE SORT");
        Array.Sort(thirdGrade, (x, y) => x.age.CompareTo(y.age));
        PrintStudentData(thirdGrade);

        Console.WriteLine("SCORE SORT");
        Array.Sort(thirdGrade, (x, y) => x.score.CompareTo(y.score));
        PrintStudentData(thirdGrade);

        Console.WriteLine("NAME LENGTH SORT");
        Array.Sort(thirdGrade, (x, y) => x.name.Length.CompareTo(y.name.Length));
        PrintStudentData(thirdGrade);

        Console.WriteLine("GENDER AND NAME SORT");
        SortByGenderAndName(thirdGrade);
    }

    private static void PrintStudentData(Student[] students)
    {
        for (int i = 0; i < students.Length; i++)
        {
            Console.WriteLine(new string('-', 10));

            Console.WriteLine(students[i].ID);
            Console.WriteLine(students[i].name);
            Console.WriteLine(students[i].age);
            Console.WriteLine(students[i].gender);
            Console.WriteLine(students[i].score);
        }

        Console.WriteLine("\n");
    }

    private static void SortByGenderAndName(Student[] students)
    {
        int maleStudentCounter = 0;
        int femaleStudentCounter = 0;

        for (int i = 0; i < students.Length; i++)
        {
            if (students[i].gender == 'm')
            {
                maleStudentCounter++;
            }
        }

        Student[] maleStudents = new Student[maleStudentCounter];
        Student[] femaleStudents = new Student[students.Length - maleStudentCounter];

        maleStudentCounter = 0;

        for (int i = 0; i < students.Length; i++)
        {
            if (students[i].gender == 'm')
            {
                maleStudents[maleStudentCounter].ID = students[i].ID;
                maleStudents[maleStudentCounter].name = students[i].name;
                maleStudents[maleStudentCounter].age = students[i].age;
                maleStudents[maleStudentCounter].gender = students[i].gender;
                maleStudents[maleStudentCounter].score = students[i].score;

                maleStudentCounter++;
            }
            else if (students[i].gender == 'f')
            {
                femaleStudents[femaleStudentCounter].ID = students[i].ID;
                femaleStudents[femaleStudentCounter].name = students[i].name;
                femaleStudents[femaleStudentCounter].age = students[i].age;
                femaleStudents[femaleStudentCounter].gender = students[i].gender;
                femaleStudents[femaleStudentCounter].score = students[i].score;

                femaleStudentCounter++;
            }
        }

        Array.Sort(maleStudents, (x, y) => x.name.CompareTo(y.name));
        Array.Sort(femaleStudents, (x, y) => x.name.CompareTo(y.name));

        PrintStudentData(maleStudents);
        PrintStudentData(femaleStudents);
    }
}
