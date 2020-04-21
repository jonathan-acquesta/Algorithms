using System;
using System.IO;

namespace BodyMassIndex
{
    class Program
    {
        static void Main(string[] args)
        {
            //nome, idade, peso e altura

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

            } while (!double.TryParse(Console.ReadLine(), out bodyWeight));


            double height = 0;
            do
            {
                Console.Write("Height (Meters): ");

            } while (!double.TryParse(Console.ReadLine(), out height));


            double bodyMassIndex = Math.Pow((bodyWeight / height), 2);
            
            Console.WriteLine($"Body Mass Index: {bodyMassIndex}");

            ////Oldways to concat strings, just to show:
            //Console.WriteLine(string.Concat("Body Mass Index: ", bodyMassIndex));
            //Console.WriteLine(string.Format("Body Mass Index: {0}", bodyMassIndex));
            //Console.WriteLine("Body Mass Index: " + bodyMassIndex);

            string directory = @"C:\Projects\";
            if (!Directory.Exists(directory)) { Directory.CreateDirectory(directory); }

            string filePath = $@"{directory}bodyMassIndex.txt";
            if (!File.Exists(filePath)) 
            {
                var file = File.CreateText(filePath);
                file.WriteLine(WriteFormatLine("Name", "Age", "Body Weight", "Height", "Body Mass Index"));
                file.Dispose();
            }

            using (StreamWriter streamWriter =  File.AppendText(filePath))
            {
                streamWriter.WriteLine(WriteFormatLine(name, age.ToString(), bodyWeight.ToString(), height.ToString(), bodyMassIndex.ToString("N2")));
            }

        }

        private static string WriteFormatLine(string name, string age, string bodyWeight, string height, string bodyMassIndex)
        {
            return $"|{name.PadRight(2, ' '),-60}|{age.ToString().PadRight(2, ' '),-15}|{bodyWeight.PadRight(2, ' '),-15}|{height.PadRight(2, ' '),-15}|{bodyMassIndex.PadRight(2, ' '),-15}";
        }
    }
}
