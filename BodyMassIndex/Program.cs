using System;
using System.Globalization;
using System.IO;
using System.Threading;

namespace BodyMassIndex
{
    class Program
    {
        #region Fields

        private const string YesAnswer = "YES";

        const string directory = @"C:\Projects\";

        static string filePath = $@"{directory}bodyMassIndex.txt";

        static CultureInfo culture = new CultureInfo("en-US");

        #endregion

        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = culture;

            CreateFile();
            ShowDataInFile();

            QuestionAboutAddNewItem();
            var answer = Console.ReadLine();

            while (answer.ToUpper() == YesAnswer)
            {
                AddNewItem();

                Console.Clear();
                ShowDataInFile();

                QuestionAboutAddNewItem();
                answer = Console.ReadLine();
            }

        }

        private static void QuestionAboutAddNewItem()
        {
            Console.WriteLine("Do you want to inform a new person? (Yes or No)");
        }

        private static void AddNewItem()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();

            int age = 0;
            do
            {
                Console.Write("Age: ");

            } while (!int.TryParse(Console.ReadLine(), out age));

            double bodyWeight = 0;
            do
            {
                Console.Write("Body Weight (Kg): ");

            } while (!double.TryParse(Console.ReadLine().Replace(",", "."), out bodyWeight));


            double height = 0;
            do
            {
                Console.Write("Height (Meters): ");

            } while (!double.TryParse(Console.ReadLine().Replace(",", "."), out height));


            double bodyMassIndex = bodyWeight / (height * height);

            Console.WriteLine($"Body Mass Index: {bodyMassIndex}");

            ////Oldways to concat strings, just to show:
            //Console.WriteLine(string.Concat("Body Mass Index: ", bodyMassIndex));
            //Console.WriteLine(string.Format("Body Mass Index: {0}", bodyMassIndex));
            //Console.WriteLine("Body Mass Index: " + bodyMassIndex);

            WriteDataInFile(name, age, bodyWeight, height, bodyMassIndex);
        }

        private static void WriteDataInFile(string name, int age, double bodyWeight, double height, double bodyMassIndex)
        {
            using (StreamWriter streamWriter = File.AppendText(filePath))
            {
                streamWriter.WriteLine(WriteFormatLine(name, age.ToString("N0", culture), bodyWeight.ToString("N2", culture), height.ToString("N2", culture), bodyMassIndex.ToString("N2", culture)));
            }
        }

        private static void ShowDataInFile()
        {
            Console.WriteLine("Current data file".PadLeft(70, '-').PadRight(125, '-'));
            Console.WriteLine("");

            string[] lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine($"_".PadLeft(125, '_'));
            Console.WriteLine("");
        }

        private static void CreateFile()
        {
            if (!Directory.Exists(directory)) { Directory.CreateDirectory(directory); }

            if (!File.Exists(filePath))
            {
                var file = File.CreateText(filePath);
                file.WriteLine(WriteFormatLine("Name", "Age", "Body Weight", "Height", "Body Mass Index"));
                file.Dispose();
            }
        }

        private static string WriteFormatLine(string name, string age, string bodyWeight, string height, string bodyMassIndex)
        {
            return $"|{name.PadRight(2, ' '),-60}|{age.PadRight(2, ' '),-15}|{bodyWeight.PadRight(2, ' '),-15}|{height.PadRight(2, ' '),-15}|{bodyMassIndex.PadRight(2, ' '),-15}";
        }
    }
}
