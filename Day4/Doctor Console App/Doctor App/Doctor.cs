using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Doctor_App
{
    class Doctor
    {
        public int Id;
        public string Name;
        public int Age;
        public int Exp;
        public string Qualification;
        public string Speciality;

        /// <summary>
        /// Constructor that initialises all the details of a Doctor.
        /// </summary>
        /// <param name="id">Integer ID</param>
        /// <param name="name">Name in String</param>
        /// <param name="age">Age in Int</param>
        /// <param name="exp">Work Experience years in Int</param>
        /// <param name="qualification">Qualification in String</param>
        /// <param name="specality">Department of Specialisation in String</param>
        public Doctor(int id,string name, int age, int exp, string qualification, string specality) 
        {
            Name = name;  
            Id = id;
            Age = age;
            Exp = exp;
            Qualification = qualification;
            Speciality = specality;
        }

        /// <summary>
        /// Displays all the details of the object in the console.
        /// </summary>
        public void displayDetails()
        {
            Console.WriteLine("ID: "+Id);
            Console.WriteLine("Name: "+Name);
            Console.WriteLine("Age: " + Age);
            Console.WriteLine("Experience: " + Exp);
            Console.WriteLine("Qualification: " + Qualification);
            Console.WriteLine("Speciality: " + Speciality);
        }
    }
}
