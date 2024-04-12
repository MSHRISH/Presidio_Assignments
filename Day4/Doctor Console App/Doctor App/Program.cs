using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Doctor_App
{
    class Program
    {
        /// <summary>
        /// Gets details from the console and creates a Doctor object.
        /// </summary>
        /// <param name="id">ID of the Doctor in INT</param>
        /// <returns>A Doctor  object reference</returns>
        static Doctor createDoctor(int id)
        {
            Console.Write("Enter Name: ");
            string Name = Console.ReadLine();

            Console.Write("Enter Age: ");
            int Age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Experience: ");
            int Exp=Convert.ToInt32(Console.ReadLine());
            
            Console.Write("Enter Qualification: ");
            string Qualification=Console.ReadLine();
            
            Console.Write("Enter Speciality: ");
            string Speciality=Console.ReadLine();
            Console.WriteLine();
            
            return new Doctor(id, Name, Age, Exp, Qualification, Speciality); ;
        }
        static void Main(string[] args)
        {
         
            Doctor[] doctors = new Doctor[3];
            Console.WriteLine("Enter Details for Doctors:");
            for(int i=0;i<doctors.Length;i++)
            {
                doctors[i]=createDoctor(100+i);
            }

            Console.WriteLine("Displaying Details: ");

            for(int i=0;i<doctors.Length;i++) 
            {
                doctors[i].displayDetails();
                Console.WriteLine();
            }

            Console.Write("Enter a Speciality to display all the doctors in that field:");
            string speciality=Console.ReadLine();

            for(int i=0;i<doctors.Length;i++)
            {
                if (doctors[i].Speciality == speciality)
                {
                    Console.WriteLine("Doctor Details:");
                    doctors[i].displayDetails();
                    Console.WriteLine();    
                }
            }



           
            
            
        }
    }
}
