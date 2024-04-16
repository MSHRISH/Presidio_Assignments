namespace ModelLibrary
{
    public class Employee
    {
        public string DepartmentName {  get; set; }

        int age;
        public int Id { get; set; }
        public int ServiceYears { get; set; }
        DateTime dob;
        public string Name { get; set; } = string.Empty;

        public double totalPF { get; set; }
        public double employeeContribution { get; set; }
        public double employerContribution { get; set; }

        public double gratuityAmount { get; set; }
        public int Age
        {
            get
            {
                return age;
            }
        }
        public DateTime DateOfBirth
        {
            get => dob;
            set
            {
                dob = value;
                age = ((DateTime.Today - dob).Days) / 365;
            }
        }
        public double Salary { get; set; }

        public Employee()
        {
            Id = 0;
            Name = string.Empty;
            Salary = 0.0;
            DateOfBirth = new DateTime();
            DepartmentName =string.Empty;
            ServiceYears = 0;
        }

        public Employee(int id, string name, DateTime dateOfBirth, double salary,string departmentname,int serviceyears)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            Salary = salary;
            DepartmentName=departmentname;
            ServiceYears = serviceyears;
        }

        public void BuildEmployeeFromConsole()
        {
            Console.WriteLine("Please enter the Name");
            Name = Console.ReadLine() ?? String.Empty;
            Console.WriteLine("Please enter the Date of birth");
            DateOfBirth = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Please enter the Basic Salary");
            Salary = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please enter the department Name:");
            DepartmentName=Console.ReadLine()??String.Empty;
            Console.WriteLine("Please enter the Service Years");
            ServiceYears = Convert.ToInt16(Console.ReadLine());
        }

        public virtual void PrintEmployeeDetails()
        {
            Console.WriteLine("Employee Id : " + Id);
            Console.WriteLine("Employee Name " + Name);
            Console.WriteLine("Date of birth : " + DateOfBirth);
            Console.WriteLine("Employee Age : " + Age);
            Console.WriteLine("Employee Salary : Rs." + Salary);
            Console.WriteLine("Employee Department Name: "+DepartmentName);
            Console.WriteLine("Employee Service Years: "+ServiceYears);
        }
    }
}
