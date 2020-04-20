using System;
using System.Collections.Generic;
using System.Linq;

namespace FilterNames
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string> {"Mary", "John", "Michael", "Ford", "Armand"};
            Console.Write("Filter names by start with: ");
            var filter = Console.ReadLine();

            Console.WriteLine("");
            Console.WriteLine("Hardway answear: ");
            Hardway(names, filter);

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Easyway answear: ");
            Easyway(names, filter);
            
        }

        static void Easyway(List<string> names, string filter)
        {
            names.FindAll(name => name.ToLower().StartsWith(filter.ToLower())).ForEach(name => Console.WriteLine(name));
        }

        static void Hardway(List<string> names, string filter)
        {
            foreach(string name in names)
            {
                if(name.ToLower().StartsWith(filter.ToLower()))
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}
