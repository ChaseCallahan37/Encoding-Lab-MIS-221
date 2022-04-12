using System;
using System.IO;
using System.Collections.Generic;

namespace FileCoder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            bool keepGoing = true;
            System.Console.WriteLine("Welcome to my file decoder!");
            PressAnyKey();

            
            while(keepGoing)
            {
                System.Console.WriteLine("What would you like to do?\n");
                DisplayMenu();
                keepGoing = Route(Console.ReadLine());
            }
        }

        static bool Route(string userInput)
        {
            bool keepGoing = true;
            switch(userInput)
            {
                case "1":
                    Encode();
                    break;
                case "2":
                    Decode();
                    break;
                case "3":
                    WordCount();
                    break;
                case "4":
                    keepGoing = false;
                    break;
                default:
                    System.Console.WriteLine("You entered an invalid input, please enter an number");
                    PressAnyKey();
                    break;
            }
            return keepGoing;
        }

        static void DisplayMenu()
        {
            System.Console.WriteLine("1. Encode\n2. Decode\n3. Word Count\n4. Exit");
        }

        static void Encode()
        {
            Console.Clear();

            System.Console.WriteLine("This is the encoder option!");
            PressAnyKey();
            System.Console.WriteLine("what is the name of the in file?");
            string inFileName = Console.ReadLine();
            
            System.Console.WriteLine("What is the name of the out file?");
            string outFileName = Console.ReadLine();

            ProcessCoder(inFileName, outFileName);


        }

        static void ProcessCoder(string inFileName, string outFileName)
        {
            string newLine = "";
            StreamReader inFile = new StreamReader($"{inFileName}.txt");
            StreamWriter outFile = new StreamWriter($"{outFileName}.txt");

            string line = inFile.ReadLine();
            while(line != null)
            {
                newLine = CodeLine(line);
                outFile.WriteLine(newLine);
                line = inFile.ReadLine();
            }
            inFile.Close();
            outFile.Close();
        }

        static string CodeLine(string line)
        {
            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string newLine = "";
            line = line.ToUpper();

            for(int u = 0; u < line.Length; u++) 
            {
                int found = -1;
                for(int j = 0; j < letters.Length; j++)
                {
                    if(line[u] == letters[j])
                    {
                        found = j;
                    }
                }
                if(found == -1)
                {
                    newLine += line[u];
                }
                else
                {
                    newLine += letters[((found + 13)%26)];
                }
            }
            return newLine;
        }

        static void Decode()
        {
            Console.Clear();
            System.Console.WriteLine("This is the decoder option!");
            PressAnyKey();

            System.Console.WriteLine("what is the name of the in file?");
            string inFile = Console.ReadLine();
            
            System.Console.WriteLine("What is the name of the out file?");
            string outFile = Console.ReadLine();

            ProcessCoder(inFile, outFile);
        }

        static void WordCount()
        {
            Console.Clear();
            System.Console.WriteLine("This is the word counter option!");
            PressAnyKey();

            System.Console.WriteLine("What is the name of the file that you would like to know the work count for?");
            string inFileName = Console.ReadLine();

            GetFileWordCount(inFileName);
        }

        static void GetFileWordCount(string inFileName)
        {
            int count = 0;
            StreamReader inFile = new StreamReader($"{inFileName}.txt");
            string line = inFile.ReadLine();

            while(line != null)
            {
                FindWords(ref count, line);
                line = inFile.ReadLine();
            }
            inFile.Close();
            System.Console.WriteLine($"File '{inFileName}' has a word count of {count}!");
            PressAnyKey();

        }

        static void FindWords(ref int count, string line)
        {
            for(int u = 0; u < line.Length; u ++)
            {
                if(line[u] == ' ' || u == (line.Length - 1))
                {
                    count++;
                }
            }
        }

        static void PressAnyKey()
        {
            System.Console.WriteLine("\n...Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}