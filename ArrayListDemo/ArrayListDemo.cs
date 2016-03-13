using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayListDemo
{
    class Student
    {
        public string name { get; set; }
        public int id { get; set; }
        private static int nextId = 1001;


        public Student(string name)
        {
            this.name = name;
            id = nextId++;
        }

        static public void showClassDemo()
        {
            ArrayList stringArray = new ArrayList(2);
            stringArray.Add(new Student("Edward"));
            stringArray.Add(new Student("Will"));
            stringArray.Add(new Student("Charlie"));
            stringArray.Add(new Student("Jack"));
            stringArray.Add(new Student("Gilbert"));

            // stringArray[1] = "Willie";

            for (int i = 0; i < stringArray.Count; i++)
            {
                Console.WriteLine(stringArray[i]);
            }
        }

        public override string ToString()
        {
            return name;
        }

        static public void showStringDemo()
        {
            ArrayList stringArray = new ArrayList(2);
            stringArray.Add("Edward");
            stringArray.Add("Will");
            stringArray.Add("Charlie");
            stringArray.Add("Jack");
            stringArray.Add("Gilbert");

            // stringArray[1] = "Willie";
            // stringArray.RemoveAt(3);

            stringArray.Sort();
            for (int i = 0; i < stringArray.Count; i++)
            {
                Console.WriteLine(stringArray[i]);
            }
        }

        static void Main(string[] args)
        {
            showStringDemo();
            // showClassDemo();
        }
    }
}
