using RequestTrackerModelLibrary;
namespace demo_app
{
    internal class Program
    {
        Employee[] employees;
        /// <summary>
        /// Constructor
        /// </summary>
        public Program()
        {
            employees = new Employee[5];
        }
        void PrintMenu()
        {
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Print All Employees");
            Console.WriteLine("3. Search Employee");
            Console.WriteLine("4. Update Employee");
            Console.WriteLine("5. Delete Employee");
            Console.WriteLine("0. Exit");
        }

        void EmployeeInteraction()
        {
            int choice = 0;
            do
            {
                PrintMenu();
                Console.WriteLine("Please select an option");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Bye.....");
                        break;
                    case 1:
                        addEmployee();
                        break;
                    case 2:
                        printAllEmployee();
                        break;
                    case 3:
                        searchEmployee();
                        break;
                    case 4:
                        updateEmployee();
                        break;
                    case 5:
                        deleteEmployee();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again");
                        break;
                }
            } while (choice != 0);
        }
        /// <summary>
        /// Adds an employee into the list. If the array is full then it prints error.
        /// </summary>
        void addEmployee()
        {
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] == null)
                {
                    employees[i] = CreateEmployee(100+i);
                    return;
                }
            }
            Console.WriteLine("Sorry we have reached the maximum number of employees");
        }
        /// <summary>
        /// Creates an employee object and returns the reference.
        /// </summary>
        /// <param name="id">Employee Id</param>
        /// <returns>Reference to the created employee object</returns>
        Employee CreateEmployee(int id)
        {
            Employee employee = new Employee();
            employee.Id = id;
            employee.BuildEmployeeFromConsole();
            return employee;
        }

        /// <summary>
        /// Prints a single employee
        /// </summary>
        /// <param name="employee">Employee object reference</param>
        void printEmployee(Employee employee)
        {
            Console.WriteLine("------------------");
            employee.PrintEmployeeDetails();
            Console.WriteLine("------------------");
        }

        /// <summary>
        /// Print all the details of the employees in the array.
        /// </summary>
        void printAllEmployee()
        {
            for(int i=0; i<employees.Length;i++)
            {
                if (employees[i] == null)
                {
                    continue;
                }
                printEmployee(employees[i]);
            }
        }
        /// <summary>
        /// Get employee ID from console
        /// </summary>
        /// <returns>Returns the id</returns>
        int GetIdFromConsole()
        {
            int id = 0;
            Console.WriteLine("Please enter the employee Id");
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid entry. Please try again");
            }
            return id;
        }
        
        /// <summary>
        /// Fetches for one employee using id
        /// </summary>
        /// <param name="id">employee id</param>
        /// <returns>Returns the employee obkect refernce if present else returns null.</returns>
        Employee fetchEmployee(int id)
        {
            Employee employee = null;
            for (int i = 0; i < employees.Length; i++)
            {

                if (employees[i] != null && employees[i].Id == id)
                {
                    employee = employees[i];
                    break;
                }
            }
            return employee;
        }

        /// <summary>
        ///Searches for a employee ID and prints  
        /// </summary>
        void searchEmployee()
        {
            int id=GetIdFromConsole();
            Employee employee = fetchEmployee(id);
            if(employee != null)
            {
                Console.WriteLine("Employee Details:");
                printEmployee(employee);
                return;
            }
            Console.WriteLine("Match not Found");
            return;
        }

        /// <summary>
        /// Updates the employee
        /// </summary
        void updateEmployee()
        {
            int id=GetIdFromConsole() ;
            Employee employee = fetchEmployee(id);

            if(employee != null)
            {
                printEmployee(employee);
                Console.WriteLine("----------------------------");
                Console.WriteLine("Update the details aptly: ");
                employee.BuildEmployeeFromConsole();
                return;
            }
            Console.WriteLine("Error Employee doesn't exist.");
        }

        /// <summary>
        /// Delete a employee if present.
        /// </summary>
        void deleteEmployee()
        {
            int id=GetIdFromConsole();
            Employee employee = fetchEmployee(id);

            printEmployee(employee);
            Console.WriteLine("Are you sure you want to delete?Y/N: ");
            if (Console.ReadLine() == "Y")
            {
                employees[id-100] = null;
            }
            else if (Console.ReadLine() == "N")
            {
                Console.WriteLine("Delete Aborted");
            }
            else
            {
                Console.WriteLine("Invalid Input!");
            }
           

        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.EmployeeInteraction();
            
        }
    }
}
