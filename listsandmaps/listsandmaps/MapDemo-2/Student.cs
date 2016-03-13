using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapDemo_2
{
    class Student
    {
        private double _gpa;
        public string name { get; set; }

        public double gpa { get { return _gpa;} }
        private int total_grades;

        public void addGrade(double newGrade)
        {
            _gpa = (_gpa * total_grades + newGrade) / (total_grades+1);
            total_grades++;
        }

        public bool Equals(Student o)
        {
            return this.name.Equals(o.name);
        }

        public override bool Equals(object obj)
        {
            Student o = (Student)obj;
            return this.Equals(o);
        }
    }
}