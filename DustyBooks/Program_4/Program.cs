
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Program_4
{
   
    class DustyBooks
    {
        int totalWords;
        public void printAverage(List<KeyValuePair<string, int>> list,string path)
        {
            int uniques = list.Count();
            int average = (totalWords/uniques);
            string filePath = path;
            list.Reverse();
            string mostUsed= "";
            foreach (KeyValuePair<string, int> kvp in list)
            {
                mostUsed = kvp.Key;
                break;
            }

            Console.WriteLine("The file path is {0}", filePath);
            Console.WriteLine("Total number of unique words: {0}", uniques);
            Console.WriteLine("Avearage number of word appearances: {0}", average);
            Console.WriteLine("The most used word is '{0}'", mostUsed);
        }

       

        public void readFile(Dictionary<string,int> myDictionary, string filePath)
        {
            string path = @filePath;
            int holdValue;
            StreamReader file = new StreamReader(path);
            {
                while (!file.EndOfStream)
                {
                    string line = file.ReadLine();
                    string[] lineSeperator = line.Split(' ');
                    foreach (string s in lineSeperator)
                    {
                        if (s != "")
                        {
                            totalWords++;
                            if (myDictionary.TryGetValue(s, out holdValue))
                            {
                                myDictionary.Remove(s);
                                myDictionary.Add(s, holdValue + 1);
                            }
                            else
                            {
                                myDictionary.Add(s, 1);
                            }
                        }
                                                   
                    }
                }
                
            }
          
        }

        public static void menu()
        {
            string filePath = "";
            Console.WriteLine("What is the file location for the book? ");
            filePath = Console.ReadLine();
            Console.Clear();
            DustyBooks dusty = new DustyBooks();
            Dictionary<string,int> uniques = new Dictionary<string, int>();
            List<string> output = new List<string>();         
            dusty.readFile(uniques,filePath);
            List<KeyValuePair<string, int>> myList = uniques.ToList();
            myList.Sort(
                delegate(KeyValuePair<string, int> firstPair,
                KeyValuePair<string, int> nextPair)
                {
                    return firstPair.Value.CompareTo(nextPair.Value);
                }
            );
            dusty.printAverage(myList,filePath);
            Console.ReadLine();
            Console.Clear();
            char choice;
            Console.WriteLine("Which query would you like to perform?\n\n");
            Console.WriteLine("(N) # of word appearances\n");
            Console.WriteLine("(A) Words that appear specified times\n");
            Console.WriteLine("(L) Words with the specified length\n");
            Console.WriteLine("(Q) Quit");
            choice = Console.ReadLine()[0];
            choice = Char.ToUpper(choice);
            Console.Clear();
            
            while (choice != 'Q')
            {
                while (choice != 'B')
                {
                    if (choice == 'N')
                    {
                        Console.WriteLine("Enter the word for query\n");
                        string readWord = Console.ReadLine();
                        int queryValue;
                        if (uniques.TryGetValue(readWord, out queryValue))
                            Console.WriteLine("'{0}' appears {1} times.", readWord, queryValue);
                        else
                            Console.WriteLine("'{0}' is not in the book", readWord);
                        Console.ReadLine();
                        Console.Clear();
                        choice = 'B';
                    }

                    if (choice == 'A')
                    {
                        Console.WriteLine("Enter the number for query\n");
                        string input = Console.ReadLine();
                        int number;
                        Int32.TryParse(input, out number);
                        if(uniques.ContainsValue(number))
                        {
                            foreach(KeyValuePair<string,int>kvp in uniques)
                            {
                                if(kvp.Value == number)
                                {
                                    output.Add(kvp.Key); 
                                }
                            }
                        }
                        output.Sort();
                        Console.Clear();
                        Console.WriteLine("The follow word(s) has {0} appearances", number);
                        Console.WriteLine();
                        foreach( string s in output)
                        {
                            Console.WriteLine(s);
                        }
                        Console.ReadLine();
                        Console.Clear();
                        output.Clear();
                        choice = 'B';

                    }

                    if (choice == 'L')
                    {
                        Console.WriteLine("Enter the number for query");
                        string input = Console.ReadLine();
                        int number;
                        Int32.TryParse(input, out number);
                       
                        foreach (KeyValuePair<string, int> kvp in myList)
                        {
                            if(kvp.Key.Length == number)
                            {
                                Console.WriteLine(kvp.Key + " " + kvp.Value);
                            }
                        }
                        Console.ReadLine();
                        Console.Clear();
                        choice = 'B';
                    }
                }
                Console.WriteLine("Which query would you like to perform?\n\n");
                Console.WriteLine("(N) # of word appearances\n");
                Console.WriteLine("(A) Words that appear specified times\n");
                Console.WriteLine("(L) Words with the specified length\n");
                Console.WriteLine("(Q) Quit");
                choice = Console.ReadLine()[0];
                choice = Char.ToUpper(choice);
                Console.Clear();
            }

        }
        static void Main(string[] args)
        {

            DustyBooks.menu();
        }
    }
    public class wordsLength
    {
        public string word { get; set; }
        public int times { get; set; }
        public wordsLength(int times, string words)
        {
            this.word = word;
            this.times = times;
        }
    
    }

}

