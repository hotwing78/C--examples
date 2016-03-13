using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsFromFile
{

    /*
    public class StudentComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            Student s1 = (Student)x;
            Student s2 = (Student)y;
            if (s1.id < s2.id)
                return -1;
            if (s1.id > s2.id)
                return 1;
            return 0;
        }
    }
    */

    class Student : IComparable<Student>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int id { get; set; }
        private double gpa;
        private List<double> grades = new List<double>(1);

        public double getGPA()
        {
            double total = 0;
            if (grades.Count == 0)
                return 0;

            foreach (double grade in grades)
            {
                total += grade;
            }

            return total / grades.Count;
        }

        public void addGrade(double grade)
        {
            grades.Add(grade);
        }

        public int CompareTo(Student other)
        {
            int relationship = this.LastName.CompareTo(other.LastName);
            if (relationship == 0)
                return this.FirstName.CompareTo(other.FirstName);
            return relationship;
        }

        static void Main(string[] args)
        {
            List<Student> studentList = new List<Student>(10);
            // StreamReader reader = new StreamReader(new FileStream("C:/cpt-244/students.csv", FileMode.Open, FileAccess.Read));
            string students = "Bond,James,33,44,55\n" +
                              "St. James,Susan,93,44,55\n" +
                              "St. John,Jill,98,44,55";

            StringReader reader = new StringReader(students);
            studentList.Add("sue");

            while (reader.Peek() != -1)
            {
                char[] delim = { ',', ':' };
                string line = reader.ReadLine();
                string[] fields = line.Split(delim);

                Student student = new Student();
                student.LastName = fields[0];
                student.FirstName = fields[1];
                student.id = int.Parse(fields[2]);
                for (int i = 3; i < fields.Length; i++)
                {
                    student.addGrade(double.Parse(fields[i]));
                }

                studentList.Add(student);
            }

            studentList.Sort();
            // studentList.Sort(new StudentComparer());

            Student jb = new Student();
            jb.FirstName = "James";
            jb.LastName = "Bond";

            int ndx = studentList.BinarySearch(jb);
            if (ndx >= 0)
            {
                Student s = (Student)studentList[ndx];
                Console.WriteLine("Name: {0} {1}", s.FirstName, s.LastName);
                Console.WriteLine("ID: {0}", s.id);
                Console.WriteLine("GPA: {0:F2}", s.getGPA());
            }
            return;

            /*
            foreach (Student s in studentList)
            {
                Console.WriteLine("==============================");
                Console.WriteLine("Name: {0} {1}", s.FirstName, s.LastName);
                Console.WriteLine("ID: {0}", s.id);
                Console.WriteLine("GPA: {0:F2}", s.getGPA());
            }
            */
        }


    }
}
