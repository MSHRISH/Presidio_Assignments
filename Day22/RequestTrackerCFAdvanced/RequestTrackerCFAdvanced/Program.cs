
using Models;
using RequestTrackerBLLibrary;
using System.ComponentModel;

namespace RequestTrackerCFAdvanced
{
    internal class Program
    {
        public static void UserLogin()
        {
            Console.WriteLine("Enter Employee ID: ");
            int EmployeeId=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Password: ");
            string Password= Console.ReadLine();
            EmployeeLoginBL employeeLoginBL = new EmployeeLoginBL();
            bool Login = employeeLoginBL.UserLogin(EmployeeId, Password).GetAwaiter().GetResult();
            if (Login)
            {
                Console.WriteLine($"User Logged in as {EmployeeId}");
                UserMenu(EmployeeId);
            }
            Console.WriteLine("Loggin Failed");
            return;
         }
        public static void UserMenu(int EmployeeId)
        {
            UserBL userBL = new UserBL();
            while (true)
            {
                Console.WriteLine("User Menu: ");
                Console.WriteLine("Enter Your Choice: ");
                Console.WriteLine("1. Raise Request");
                Console.WriteLine("2. View Request Status");
                Console.WriteLine("3. View Solutions");
                Console.WriteLine("4. Give Feedback");
                Console.WriteLine("5. Respond to Solution");
                Console.WriteLine("6. Log out");
                int choice=Convert.ToInt32(Console.ReadLine());

                switch(choice)
                {
                    case 1:
                        RaiseRequest(EmployeeId, userBL);
                        break;
                    case 2:
                        ViewRequestStatus(userBL);
                        break;
                    case 3:
                        ViewSolutions(userBL);
                        break;  
                    case 4:
                        GiveFeedback(userBL,EmployeeId);
                        break;
                    case 5:
                        RespondToSolution(userBL);
                        break;
                    case 6:
                        return;
                    default:
                        break;
                }
            }
        }
        public static void RaiseRequest(int EmployeeId,UserBL userBL)
        {
            Console.WriteLine("Enter RequestMessage: ");
            string RequestMessage=Console.ReadLine();
            int RequestId=userBL.RaiseRequest(RequestMessage,EmployeeId).GetAwaiter().GetResult();
            Console.WriteLine("Request Raised With Id: "+RequestId);
            return;
        }

        public static void ViewRequestStatus(UserBL userBL)
        {
            Console.WriteLine("Enter Request ID: ");
            int RequestId=Convert.ToInt32(Console.ReadLine());
            string RequestStatus=userBL.ViewRequestStatus(RequestId).GetAwaiter().GetResult();
            Console.WriteLine("RequestStatus: "+RequestStatus);
            return;
        }
        public static void ViewSolutions(UserBL userBL)
        {
            Console.WriteLine("Enter Request ID: ");
            int RequestId = Convert.ToInt32(Console.ReadLine());
            IList<Solution> solutions = new List<Solution>();
            solutions=userBL.ViewSolutions(RequestId).GetAwaiter().GetResult();
            foreach ( var solution in solutions )
            {
                Console.WriteLine("Solution ID: "+solution.SolutionId);
                Console.WriteLine("Solution Description: "+solution.SolutionDescription);
            }
            return;
        }
        public static void GiveFeedback(UserBL userBL,int EmployeeId)
        {
            Console.WriteLine("Enter SolutionId");
            int SolutionId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Rating: ");
            float Rating=float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Remarks: ");
            string Remarks=Console.ReadLine();

            int FeedbackId = userBL.GiveFeedback(EmployeeId, Rating, Remarks, SolutionId).GetAwaiter().GetResult();
            Console.WriteLine("FeedBack Given. FeedBack ID: " + FeedbackId);
            return;
        }
        public static void RespondToSolution(UserBL userBL)
        {
            Console.WriteLine("Enter SolutionId");
            int SolutionId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Response: ");
            string Response=Console.ReadLine();

            bool Respond = userBL.RespondToSolution(SolutionId, Response).GetAwaiter().GetResult();
            Console.WriteLine("Response Added!");
            return;
        }
        public static void LoginMenu()
        {
            while (true)
            {
                Console.WriteLine("Enter Your Choice: ");
                Console.WriteLine("1.User Login: ");
                Console.WriteLine("2.Admin Login: ");
                Console.WriteLine("3.Exit: ");
                int choice=Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        UserLogin();
                        break;
                    case 3:
                        return;
                    default:
                        break;
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Employee!");
            LoginMenu();
        }
    }
}
