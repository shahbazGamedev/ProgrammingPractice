// Make a struct of students each having an ID, Name, Age, Gender and Score out of 100. 
// Create an Array of 10 students and sort them by:
// ID, Name, Name (reverse), Age, Score, Name Length and (first by Gender and then by Name).

using System;
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
        Student[] ThirdGrade = new Student[10];

        string[] data = File.ReadAllLines("StudentsInfo.txt");

        int currentStudent = 0;
        int currentLine = 0;
        while (currentLine < data.Length)
        {
            ThirdGrade[currentStudent].ID = data[currentLine];
            currentLine++;

            ThirdGrade[currentStudent].name = data[currentLine];
            currentLine++;

            ThirdGrade[currentStudent].age = int.Parse(data[currentLine]);
            currentLine++;

            ThirdGrade[currentStudent].gender = char.Parse(data[currentLine]);
            currentLine++;

            ThirdGrade[currentStudent].score = int.Parse(data[currentLine]);
            currentLine++;

            currentStudent++;
        }

        Console.WriteLine("ORIGINAL SORT");
        PrintStudentData(ref ThirdGrade);

        Console.WriteLine("ID SORT");
        Array.Sort(ThirdGrade, (x, y) => x.ID.CompareTo(y.ID));
        PrintStudentData(ref ThirdGrade);

        Console.WriteLine("NAME SORT");
        Array.Sort(ThirdGrade, (x, y) => x.name.CompareTo(y.name));
        PrintStudentData(ref ThirdGrade);

        Console.WriteLine("NAME REVERSE SORT");
        Array.Sort(ThirdGrade, (x, y) => y.name.CompareTo(x.name));
        PrintStudentData(ref ThirdGrade);

        Console.WriteLine("AGE SORT");
        Array.Sort(ThirdGrade, (x, y) => x.age.CompareTo(y.age));
        PrintStudentData(ref ThirdGrade);

        Console.WriteLine("SCORE SORT");
        Array.Sort(ThirdGrade, (x, y) => x.score.CompareTo(y.score));
        PrintStudentData(ref ThirdGrade);

        Console.WriteLine("NAME LENGTH SORT");
        Array.Sort(ThirdGrade, (x, y) => x.name.Length.CompareTo(y.name.Length));
        PrintStudentData(ref ThirdGrade);

        // TODO:
        Console.WriteLine("GENDER AND NAME SORT");
        
        
    }

    static void PrintStudentData(ref Student[] studentsArray)
    {
        for (int i = 0; i < studentsArray.Length; i++)
        {
            Console.WriteLine(new string('-', 10));

            Console.WriteLine(studentsArray[i].ID);
            Console.WriteLine(studentsArray[i].name);
            Console.WriteLine(studentsArray[i].age);
            Console.WriteLine(studentsArray[i].gender);
            Console.WriteLine(studentsArray[i].score);
        }

        Console.WriteLine("\n\n");
    }
}

