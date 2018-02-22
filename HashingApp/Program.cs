using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HashingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Max number of array item Dictionary can hold is 150.
            const int STUDENTCOUNT = 150;
            bool running = true;

            MyDictionary<Student> md = new MyDictionary<Student>();

            for (int i = 0; i < STUDENTCOUNT; i++)
            {
                Student st = new Student();
                md.Set(st.studID.ToString(), st);
            }

            Console.WriteLine(md.ToString());

            Console.WriteLine("Either Enter a Student ID to Search or type EXIT \n");

            while (running)
            {
                Console.Write("\nCOMMAND: ");
                string input = Console.ReadLine();
                if (input.Count() == 8)
                {
                    if (input.ToUpper() != "EXIT")
                    {
                        try
                        {
                            Console.WriteLine(md.Get(input).ToString());
                        }
                        catch (NullReferenceException)
                        {
                            Console.WriteLine("Value Does not Exist in Dictionary");
                        }
                    }
                    else running = false;
                }
                else Console.WriteLine("Invalid command ID must be 8 integers.");
                
            }
            
            
            Console.WriteLine($"Dictionary Length: {md.getArrayLength()}");

            Console.ReadLine();
        }
    }
}
