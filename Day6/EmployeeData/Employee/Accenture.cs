using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    public class Accenture:Employee,IGovtRules
    {
        public Accenture(int id, string name, DateTime dob, double salary, string departmentName,int service) : base(id, name, dob, salary, departmentName,service)
        { 
            totalPF = EmployeePF(salary);
            Salary = Salary-totalPF;
        }

        public double gratuityAmountCalculation(int serviceCompleted, double basicSalary) 
        {
            return 0;
        }

        public override void PrintEmployeeDetails()
        {
            base.PrintEmployeeDetails();
            Console.WriteLine("Gratuity Not Applicable");
            Console.WriteLine("Leave Details: ");
            Console.WriteLine(LeaVeDetails());
            Console.WriteLine("Total Pension Amount: " + totalPF);
            Console.WriteLine("Employee Contribution: " + employeeContribution);
            Console.WriteLine("Employer Contribution: " + employerContribution);
        }
        public string LeaVeDetails()
        {
            return "2 day of Casual Leave per month" + "\n5 days of Sick Leave per year" + "\n5 days of Previlage Leave per year";
        }

        public double EmployeePF(double basicSalary)
        {
            employeeContribution = basicSalary*0.12;
            employerContribution = basicSalary * 0.12;
            return basicSalary*0.24;
        }
    }
}
