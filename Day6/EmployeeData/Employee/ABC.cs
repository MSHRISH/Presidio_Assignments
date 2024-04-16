using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    public class ABC:Employee, IGovtRules
    {
      
        public ABC(int id,string name,DateTime dob,double salary,string departmentName,int service):base(id,name,dob,salary,departmentName, service)
        {
            gratuityAmount = gratuityAmountCalculation(service, salary);
            totalPF=EmployeePF(salary);
            Salary=Salary-totalPF;
        }

        public double  gratuityAmountCalculation(int serviceCompleted, double basicSalary)
        {
            if (serviceCompleted < 5)
            {
                return 0;
            }
            else
            {
                if(serviceCompleted<=10)
                {
                    return basicSalary;
                }
                else
                {
                    if(serviceCompleted<=20) 
                    {
                        return basicSalary * 2;
                    }
                    else
                    {
                        return (basicSalary * 3);
                    }
                }
            }
        }

        override public void PrintEmployeeDetails()     
        {
            base.PrintEmployeeDetails();
            Console.WriteLine("Gratuity Amount Entitled: "+gratuityAmount);
            Console.WriteLine("Leave Details: ");
            Console.WriteLine(LeaVeDetails());
            Console.WriteLine("Total Pension Amount: "+totalPF);
            Console.WriteLine("Employee Contribution: " + employeeContribution);
            Console.WriteLine("Employer Contribution: " + employerContribution);
        }
        public string LeaVeDetails()
        {
            return "1 day of Casual Leave per month" + "\n12 days of Sick Leave per year" + "\n10 days of Privilege Leave per year";
        }

        public double EmployeePF(double basicSalary)
        {
            employeeContribution = basicSalary * 0.0367;
            employerContribution = basicSalary * 0.0833;
            return basicSalary*0.12;
        }
    }
}
