using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace practice
{
    public class SubStringTest
    {
        static Stack <string> GetStack()
        {
            Stack <string> myStack = new Stack<string>();
            myStack.Push("Name: Felica Walker");
            myStack.Push("Title: Mz.");
            myStack.Push("Age: 47");
            myStack.Push("Location: Paris");
            myStack.Push("Gender: F");
            return myStack;
        }
        public static void Main()
        {
            var stack = GetStack();
            Console.WriteLine("----- Stack contents -----");
            foreach (string i in stack)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
           

        }
      
    }
            
            
            


        }


 