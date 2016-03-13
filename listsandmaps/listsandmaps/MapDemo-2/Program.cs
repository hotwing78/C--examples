using System;
using System.Collections.Generic;
using System.Text;

namespace MapDemo_2
{
    class Classroom
    {
        private Dictionary<string, Student> students = new Dictionary<string, Student>();

        public void AddStudent(string name)
        {
            Student s = new Student();
            s.name = name;
            students.Add(name, s);
        }

        public void addGrade(string name, double grade)
        {
            Student s;
            if (! students.TryGetValue(name, out s))
            {
                Console.WriteLine("Bad Student");
            }
            else
            {
                s.addGrade(grade);
            }
        }

        public Boolean StudentExists(string name)
        {
            Student s = new Student();
            s.name = name;
            return students.ContainsValue(s);
        }

        public double getAverage(string name)
        {
            Student s;
            if (!students.TryGetValue(name, out s))
            {
                Console.WriteLine("Bad Student");
                return -1.0;
            }
            else
            {
                return s.gpa;
            }
        }
        static void Main(string[] args)
        {
            Classroom c = new Classroom();
            double average;
            c.AddStudent("Mary");
            c.AddStudent("Jane");
            c.addGrade("Mary", 99);
            c.addGrade("Mary", 97);
            average = c.getAverage("Mary");
            // Console.WriteLine("Mary's average is: {0}", average);
            if (c.StudentExists("Jane"))
                Console.WriteLine("She's there!");
            else
                Console.WriteLine("She's not there!");
        }
    }
}
