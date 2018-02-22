using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HashingApp
{
    public class Student
    {
        public int studID { get; private set; }
        public string name { get; private set; }
        public double gpa { get; private set; }
        public string major { get; private set; }
        public string email { get; private set; }
        static Random rd = new Random();

        public Student()
        {
            StudID();
            Name();
            Major();
            GPA();
            Email();
        }

        protected void StudID()
        {
            //Assign random number for Student ID.
            studID = rd.Next(00158268, 99999999);
        }

        protected void Name()
        {
            //Max char count of 50 is set for name.
            using (StreamReader sr = new StreamReader("StudentFiles/FirstNames.txt"))
            {
                string line;
                int nameCount = rd.Next(100);
                int increment = 0;

                while ((line = sr.ReadLine()) != null)
                {
                    if (nameCount == increment) { name = line; break; }
                    increment++;
                }
            }
        }

        protected void GPA()
        {
            int firstDigit = rd.Next(4);
            gpa = firstDigit + Math.Round(rd.NextDouble(), 2);
        }

        protected void Major()
        {
            string line;
            int majorCount = rd.Next(6);
            int increment = 0;

            using (StreamReader sr = new StreamReader("StudentFiles/StudMajor.txt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    if (majorCount == increment) { major = line; break; }
                    increment++;
                }
            }
        }

        protected void Email()
        {
            string line;
            int emailCount = rd.Next(6);
            int increment = 0;

            using (StreamReader sr = new StreamReader("StudentFiles/StudEmail.txt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    if (emailCount == increment) { email = line; break; }
                    increment++;
                }
            }
        }

        /// <summary>
        /// Student ToString method to display accurate properties.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"ID: {studID} Name: {name} GPA: {gpa} Major: {major} Email: {email}";
        }
    }
}
