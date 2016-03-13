using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Arrays
{
    class Program
    {
        static int gFindCount = 0;

        static void BubbleSort1(string[] inArray, int size)
        {
            for (int i = 1; i < inArray.Length; i++)
            {
                int comparisonsToMake = inArray.Length - 1;
                for (int j = 0; j < comparisonsToMake; j++)
                {
                    if (inArray[j].CompareTo(inArray[j + 1]) > 0)
                    {
                        string tmp = inArray[j];
                        inArray[j] = inArray[j + 1];
                        inArray[j + 1] = tmp;
                    }
                }
            }
        }

        static void BubbleSort2(string[] inArray, int size)
        {
            for (int i = 1; i < inArray.Length; i++)
            {
                int comparisonsToMake = inArray.Length - i;
                for (int j = 0; j < comparisonsToMake; j++)
                {
                    if (inArray[j].CompareTo(inArray[j + 1]) > 0)
                    {
                        string tmp = inArray[j];
                        inArray[j] = inArray[j + 1];
                        inArray[j + 1] = tmp;
                    }
                }
            }
        }

        static void BubbleSort3(string[] inArray, int size)
        {
            int lastSwap = inArray.Length - 1;
            while (lastSwap != 0)
            {
                int comparisonsToMake = lastSwap;
                lastSwap = 0;
                for (int j = 0; j < comparisonsToMake; j++)
                {
                    if (inArray[j].CompareTo(inArray[j + 1]) > 0)
                    {
                        string tmp = inArray[j];
                        inArray[j] = inArray[j + 1];
                        inArray[j + 1] = tmp;
                        lastSwap = j;
                    }
                }
            }
        }

        static void populate(int[] nums, int count)
        {
            Random r = new Random();
            for (int ndx = 0; ndx < nums.Length; ndx++)
                nums[ndx] = r.Next(count);
        }

        static int findInt(int[] list, int target, int last)
        {
            int min = 0;
            int max = last - 1;
            bool found = false;
            int middle = 0;
            // int count = 0;
            while (!found && min <= max)
            {
                middle = (min + max) / 2;
                // count++;
                int relationship = target.CompareTo(list[middle]);
                if (list[middle] < target)
                    max = middle - 1;
                else if (list[middle] > target)
                    min = middle + 1;
                else
                    found = true;
            }
            // Console.WriteLine("Count:{0,10} {1}", target + ":", count);
            // gFindCount += count;
            if (found)
                return middle;
            return -1;
        }

        static int findString(string[] list, string target, int last)
        {
            int min = 0;
            int max = last - 1;
            bool found = false;
            int middle = 0;
            while (!found && min <= max)
            {
                middle = (min + max) / 2;
                // count++;
                int relationship = target.CompareTo(list[middle]);
                if (relationship < 0)
                    max = middle - 1;
                else if (relationship > 0)
                    min = middle + 1;
                else
                    found = true;
            }
            if (found)
                return middle;
            return -1;
        }

        static void sortInt(int[] intArray, int size)
        {
            // int count = 0;
            int lastSwap = size - 1;
            while (lastSwap != 0)
            {
                int comparisonsToMake = lastSwap;
                lastSwap = 0;
                for (int j = 0; j < comparisonsToMake; j++)
                {
                    // count++;
                    if (intArray[j] < intArray[j + 1])
                    {
                        int tmp = intArray[j];
                        intArray[j] = intArray[j + 1];
                        intArray[j + 1] = tmp;
                        lastSwap = j;
                    }
                }
            }
            // Console.WriteLine("{0}", count);
        }

	static void demoSearching()
        {
            string[] names = new string[] { "Alystra", "Tegan", "Brandon", "Oliver", "Casey", "Midnight", "Jeremiah", "Maya" };
            BubbleSort(names, names.Length);
            string[] searches = new string[] {"aaron", "Alystra", "Tegan", "Brandon", "Oliver", "Casey", "Midnight", "Jeremiah", "Maya" };
            foreach (string s in searches)
            {
                int ndx = findString(names, s, names.Length);
                Console.WriteLine("{0}: at {1}", s, ndx);
            }
        }

        static void demoSortCounting()
        {
            int[] oneThousand = new int[1000];
            int[] twoThousand = new int[2000];
            int[] fourThousand = new int[4000];
            int[] eightThousand = new int[8000];
            populate(oneThousand, oneThousand.Length);
            populate(twoThousand, twoThousand.Length);
            populate(fourThousand, fourThousand.Length);
            populate(eightThousand, eightThousand.Length);
            Console.Write("One Thousand:  ");
            sortInt(oneThousand, oneThousand.Length);
            Console.Write("Two Thousand:  ");
            sortInt(twoThousand, twoThousand.Length);
            Console.Write("Four:          ");
            sortInt(fourThousand, fourThousand.Length);
            Console.Write("Eight:         ");
            sortInt(eightThousand, eightThousand.Length);
        }

        static void demoSearchTime()
        {
            int trials = 4;
            int len = 2048;
            for (int i = 0; i < trials; i++)
            {
                int[] myArray = new int[len];
                populate(myArray, len);
                DateTime start = DateTime.Now;
                sortInt(myArray, len);
                DateTime end = DateTime.Now;
                Console.WriteLine("Count: {0} -- {1}", len, end.Ticks - start.Ticks);
                len *= 2;
            }
        }

        static void demoStringSort()
        {
            string[] names = { "Alystra", "Tegan", "Brandon", "Oliver", "Casey", "Midnight", "Jeremiah", "Maya" };
            BubbleSort1(names, names.Length);
            foreach (string n in names)
                Console.Write(n + " ");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            demoStringSort();
            // demoSortCounting();
            // demoSearching();
            // demoSearchTime();
        }
    }
}
