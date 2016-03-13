using System;

namespace ArraySorting_OOP
{
    class StringArray
    {
        string[] sArray;
        int size = 0;

        public StringArray()
        {
            sArray = new string[32];
        }

        public StringArray(string[] inArray, int length)
        {
            sArray = inArray;
            size = length;
        }

        public void add(string newEntry)
        {
            sArray[size] = newEntry;
            size++;
        }

        public void BubbleSort()
        {
            int lastSwap = size - 1;
            while (lastSwap != 0)
            {
                int comparisonsToMake = lastSwap;
                lastSwap = 0;
                for (int j = 0; j < comparisonsToMake; j++)
                {
                    if (sArray[j].CompareTo(sArray[j + 1]) > 0)
                    {
                        string tmp = sArray[j];
                        sArray[j] = sArray[j + 1];
                        sArray[j + 1] = tmp;
                       
                    } lastSwap = j;
                        
                }
            }
        }

        public int findString(string target)
        {
            int min = 0;
            int max = size - 1;
            bool found = false;
            int middle = 0;

            while (!found && min <= max)
            {
                middle = (min + max) / 2;

                int relationship = target.CompareTo(sArray[middle]);
                if (relationship < 0)
                    max = middle - 1;
                else if (relationship > 0)
                    min = middle + 1;
                else
                    found = true;
            }

            if (found)
            {
                return middle;
            }

            return -1;
        }


        public void PrintArray()
        {
            for (int ndx = 0; ndx < size; ndx++) //Look here for the change you made in class
            {
                Console.Write(sArray[ndx] + " ");
            }
            Console.WriteLine();
        }


        public void insertion(string name)
        {

            int min = 0;
            int max = size - 1;
            bool found = false;
            int middle = 0;
            int here = 0;
            while (!found && min <= max)
            {
                middle = (min + max) / 2;

                int relationship = name.CompareTo(sArray[middle]);
                if (relationship < 0)
                    max = middle - 1;
                else if (relationship > 0)
                    min = middle + 1;
                else
                    found = true;
            }
            string tmp = sArray[middle];
            sArray[middle] = sArray[middle + 1];
            sArray[middle + 1] = tmp;
            sArray[middle] = name;        
        }

        public void del(int inIndex)
        {
            int lastSwap = size - 1;
           
            for (int i = inIndex; i < size; i++)
            {
                string tmp = sArray[i];
                sArray[i] = sArray[i + 1];
                sArray[i + 1] = tmp;
                lastSwap = i;
            }
                size--;
        }

       

        public static void demoStringSort()
        {
            string cat;
            int ndx;
            StringArray myArray = new StringArray();
            myArray.add("Tegan");
            myArray.add("Alystra");
            myArray.add("Brandon");
            myArray.add("Oliver");
            myArray.add("Casey");
            myArray.add("Midnight");
            myArray.add("Jeremiah");
            myArray.add("Maya");

            myArray.BubbleSort();
            myArray.PrintArray();
            cat = "Midnight";
            ndx = myArray.findString(cat);
            Console.WriteLine("{0} found at index: {1}", cat, ndx);
        }

        public static void demoSortingInput()
        {
            StringArray myArray = new StringArray();
            string name;
            Console.Write("Enter a name ('quit' to stop': ");
            name = Console.ReadLine();
            while (name != "quit")
            {
                myArray.add(name);
                Console.Write("Enter a name ('quit' to stop': ");
                name = Console.ReadLine();
            }

            myArray.BubbleSort();
            myArray.PrintArray();
        }

        
        public static void menu()
        {
            char c;
            string name;
            StringArray myArray = new StringArray();
            Console.WriteLine("Choose from the following options:" + "\n" + "\n"+
               "(I)nsert" + "\n" + "(D)elete" + "\n" + "Display (A)ll" + "\n" + "(Q)uit");
            c = Console.ReadLine()[0];
            c = Char.ToUpper(c);
            while (c != 'Q')
            {
                while (c != 'N')
                {
                    if (c == 'I')
                    {
                        while (c != 'N')
                        {
                            Console.Clear();
                            Console.Write("Enter a name: ");
                            name = Console.ReadLine();
                            myArray.insertion(name);
                            Console.Write("Continue? (Y)/(N)");
                            c = Console.ReadLine()[0];
                            c = Char.ToUpper(c);
                        }
                    }
                    else if (c == 'D')
                    {
                        int search;
                        Console.Clear();
                        Console.WriteLine("Enter name for deletion: ");
                        name = Console.ReadLine();
                        search =  myArray.findString(name);
                        myArray.del(search);
                        c = 'N';

                    }
                    else if (c == 'A')
                    {
                        Console.Clear(); 
                        myArray.PrintArray();
                        Console.ReadLine();
                        c = 'N';

                    }
                }
                Console.Clear();
                Console.WriteLine("Choose from the following options:" + "\n" + "\n" +
               "(I)nsert" + "\n" + "(D)elete" + "\n" + "Display (A)ll" + "\n" + "(Q)uit");
                c = Console.ReadLine()[0];
                c = Char.ToUpper(c);
              }
           }

    

        static void Main(string[] args)
        {
           
            //StringArray.demoStringSort();
           //StringArray.demoSortingInput();
           //Console.ReadLine();
           StringArray.menu();
              
         }
        
    }
}

