using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;

/*
 * Developers: Sara Jade, Jose Cheyo Jimenez, Tyler Walser
 * 9/1/17
 * 
 * class Concordance has been updated with the following features:
 * 1) using static System.Console;
 * 2) exceptions thrown appropriate for WPF project
 * 3) WPF display based on files of output text from previous lab
 * 
 * TODO: Update code to display to WPF window based on analyzed input file.
 * 
 */


namespace TLG
{
    public class Concordance
    {
        public static string inPath = string.Empty;
        public static string outPath = string.Empty;
        public static string excludedWordsPath = string.Empty;
        public static string inputText = string.Empty;
        public static string outputText = string.Empty;
        public static string[] excludedWords;
        public static string[] outputFilePaths = new string[4];

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

            // TODO: fix this method!
            StartConcordance(anlz.Paragraphs, excludedWords);

            ReadKey();
        }

        public static void ReadInputs()
        {
            // No need for try-catch block because program already throws
            // appropriate exception when it can't find a file.
            inputText = File.ReadAllText(inPath);
            excludedWords = File.ReadAllLines(excludedWordsPath);

            
        }

        public static void GetPaths(string[] args)
        {
            // Get the path to the input text file
            try
            {
                inPath = Path.GetFullPath(args[0]);
            }
            catch (ArgumentException)
            {
                throw new ArgumentException($"Invalid text input path {args[0]}");
            }

            // Get the path for the output file
            try
            {
                outPath = Path.GetFullPath(args[1]);
            }
            catch (ArgumentException)
            {
                throw new ArgumentException($"Invalid text output path {args[1]}");
            }

            // Get the path to the excluded words file
            try
            {
                excludedWordsPath = Path.GetFullPath(args[2]);
            }
            catch (ArgumentException)
            {
                throw new ArgumentException($"Invalid excluded words input path {args[1]}");
            }

            outputFilePaths[0] = Path.Combine(outPath, "0.txt");
            outputFilePaths[1] = Path.Combine(outPath, "1.txt");
            outputFilePaths[2] = Path.Combine(outPath, "2.txt");
            outputFilePaths[3] = Path.Combine(outPath, "3.txt");
        }

    }
}
