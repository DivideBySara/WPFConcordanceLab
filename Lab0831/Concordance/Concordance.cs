using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;

namespace TLG
{
    class Concordance
    {
        static string inPath = string.Empty;
        static string outPath = string.Empty;
        static string excludedWordsPath = string.Empty;
        static string inputText = string.Empty;
        static string outputText = string.Empty;
        static string[] excludedWords;

        static void Main(string[] args)
        {

            Analyzer anlz = new Analyzer();

            // Set up paths from args
            if (args.Length != 3)
            {
                Console.WriteLine("Invalid number of path specifications");
                return;
            }
            GetPaths(args);
            // Get the input data
            ReadInputs();
            // Identify paragraphs and sentences
            // Identify words and their location
            anlz.Analyze(inputText);

            ReadKey();
        }

        static void ReadInputs()
        {
            try
            {
                inputText = File.ReadAllText(inPath);
                excludedWords = File.ReadAllLines(excludedWordsPath);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error reading file " + e.Message);
            }
        }

        static void GetPaths(string[] args)
        {
            // Get the path to the input text file
            try
            {
                inPath = Path.GetFullPath(args[0]);
            }
            catch (ArgumentException)
            {
                Console.WriteLine($"Invalid text input path {args[0]}");
            }

            // Get the path for the output file
            try
            {
                outPath = Path.GetFullPath(args[1]);
            }
            catch (ArgumentException)
            {
                Console.WriteLine($"Invalid text output path {args[1]}");
            }

            // Get the path to the excluded words file
            try
            {
                excludedWordsPath = Path.GetFullPath(args[2]);
            }
            catch (ArgumentException)
            {
                Console.WriteLine($"Invalid excluded words input path {args[1]}");
            }
        }

    }
}
