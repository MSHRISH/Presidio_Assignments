using  ModelLibrary;

namespace EmployeeData
{
    internal class Program
    {

        static void Main(string[] args)
        { 
            
            Console.WriteLine("Enter Company Name: ");
            string company = Console.ReadLine() ?? String.Empty;
            if(company == "ABC")
            {
                ABC employeeABC = new ABC(100,"shrish",new DateTime(1985,09,09),25000,"IT",12);
                employeeABC.PrintEmployeeDetails();
                
            }
            else
            {
                Accenture emmployeeAccenture = new Accenture(101, "raghul", new DateTime(2000,08,09), 27000, "Support",15);
                emmployeeAccenture.PrintEmployeeDetails();
            }


        }
    }
}
