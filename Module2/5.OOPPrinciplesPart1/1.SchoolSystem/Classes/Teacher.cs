namespace SchoolSystem
{
    using System.Collections.Generic;

    public class Teacher : Person
    {
        public Teacher(string firstName, string lastName)
            : base(firstName, lastName)
        {
            disciplines = new List<Discipline>();
        }

        public Teacher(string firstName, string lastName, string discName, int discLecturers, int discExercises)
            : this(firstName, lastName)
        {
            disciplines = new List<Discipline>();
            disciplines.Add(new Discipline(discName, discLecturers, discExercises));
        }

        public List<Discipline> Disciplines
        {
            get
            {
                return this.disciplines;
            }
            set
            {
                this.disciplines.Add(new Discipline());
            }
        }

        private List<Discipline> disciplines;
    }
}