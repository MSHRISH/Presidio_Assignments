using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    public interface IGovtRules
    {
        public double gratuityAmountCalculation(int serviceCompleted, double basicSalary);
        public string LeaVeDetails();
        public double EmployeePF(double basicSalary);
    }
}
