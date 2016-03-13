using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FirstDemo
{
    class Demo
    {
        public string InFileName { get; set; }
        public string OutFileName { get; set; }

        public void WriteFile()
        {
            StreamWriter writer;
            if (OutFileName == null)
            {
                Console.WriteLine("No Filename Set");
                return;
            }

            writer = new StreamWriter(new FileStream(OutFileName, FileMode.Create, FileAccess.Write));
            writer.WriteLine("Hello, World");
            writer.WriteLine("Strawberry, Patch");
            writer.WriteLine("Sandy, Beach");
            writer.Close();
        }
        public void ReadFile()
        {
            StreamReader reader;
            if (InFileName == null)
            {
                Console.WriteLine("No Filename Set");
                return;
            }

            reader = new StreamReader(new FileStream(InFileName, FileMode.Open, FileAccess.Read));
            // while (reader.Peek() != -1)
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                Console.WriteLine(line);
            }
            reader.Close();
        }

        public void ReadCSV()
        {
            StreamReader reader;
            if (InFileName == null)
            {
                Console.WriteLine("No Filename Set");
                return;
            }

            reader = new StreamReader(new FileStream(InFileName, FileMode.Open, FileAccess.Read));
            // while (reader.Peek() != -1)
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] fields = line.Split(",".ToCharArray());
                for (int i = 0; i < fields.Length; i++ )
                {
                    Console.WriteLine(fields[i]);
                }
            }

            reader.Close();
        }

        static void Main(string[] args)
        {
            Demo myInstance = new Demo();
            myInstance.InFileName = @"C:\cpt-244\file1.csv";
            myInstance.OutFileName = @"C:\cpt-244\file1.csv";
            myInstance.WriteFile();
            myInstance.ReadFile();
            myInstance.ReadCSV();
        }
    }
}
