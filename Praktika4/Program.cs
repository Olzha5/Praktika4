using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika04
{
    struct Student
    {
        public string Name;
        public string GroupNumber;
        public int[] Grades;

        public double AverageGrade
        {
            get { return Grades.Average(); }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Student[] students = new Student[10];

            students[0] = new Student { Name = "Иванов И.И.", GroupNumber = "Группа 1", Grades = new int[] { 5, 4, 4, 5, 5 } };
            students[1] = new Student { Name = "Петров П.П.", GroupNumber = "Группа 1", Grades = new int[] { 4, 4, 4, 4, 4 } };
            students[2] = new Student { Name = "Сидоров С.С.", GroupNumber = "Группа 2", Grades = new int[] { 5, 5, 5, 5, 5 } };
            students[3] = new Student { Name = "Козлов К.К.", GroupNumber = "Группа 2", Grades = new int[] { 3, 3, 3, 3, 3 } };
            students[4] = new Student { Name = "Смирнов С.С.", GroupNumber = "Группа 3", Grades = new int[] { 4, 4, 4, 4, 4 } };
            students[5] = new Student { Name = "Новиков Н.Н.", GroupNumber = "Группа 3", Grades = new int[] { 5, 4, 5, 5, 4 } };
            students[6] = new Student { Name = "Морозов М.М.", GroupNumber = "Группа 4", Grades = new int[] { 4, 5, 4, 4, 4 } };
            students[7] = new Student { Name = "Васильев В.В.", GroupNumber = "Группа 4", Grades = new int[] { 4, 5, 4, 5, 4 } };
            students[8] = new Student { Name = "Зайцев З.З.", GroupNumber = "Группа 5", Grades = new int[] { 5, 5, 5, 4, 5 } };
            students[9] = new Student { Name = "Попов П.П.", GroupNumber = "Группа 5", Grades = new int[] { 3, 3, 3, 3, 3 } };

            Array.Sort(students, (x, y) => x.AverageGrade.CompareTo(y.AverageGrade));

            Console.WriteLine("Студенты с оценками 4 или 5:");
            foreach (var student in students)
            {
                if (student.Grades.All(grade => grade == 4 || grade == 5))
                {
                    Console.WriteLine($"{student.Name}, {student.GroupNumber}");
                }
            }
        }
    }
}