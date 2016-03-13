using System;
using System.Collections.Generic;
using System.Text;

namespace MapDemo_1
{
    class Program
    {

        static void Main(string[] args)
        {
            Dictionary<string, string> beatles = new Dictionary<string, string>();
            beatles.Add("George", "Harrison");
            beatles.Add("Ringo", "Starr");
            beatles.Add("Paul", "McCartney");
            beatles.Add("John", "Lennon");
            beatles["Jack"] = "Jill";

            /*
            Console.WriteLine("Jack {0}", beatles["George"]);
            Console.WriteLine("Paul {0}", beatles["Paul"]);
            Console.WriteLine("John {0}", beatles["John"]);
            Console.WriteLine("Ringo {0}", beatles["Ringo"]);

            foreach (string s in beatles.Values)
                Console.WriteLine("value: {0}", s);

            foreach (string s in beatles.Keys)
                Console.WriteLine("Keys: {0}", s);

            string lastName;
            string key = "Pall";
            if (beatles.TryGetValue(key, out lastName))
                Console.WriteLine("{0} {1}", key, lastName);
            else
                Console.WriteLine("{0} isn't in list", key);
            */

            if (beatles.ContainsValue("Lennon"))
                Console.WriteLine("Yep, Lennon is there");
            /*
            */
        }
    }
}
