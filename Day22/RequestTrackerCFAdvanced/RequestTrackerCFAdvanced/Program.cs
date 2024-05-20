
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
        public static void AdminLogin()
        {
            Console.WriteLine("Enter Employee ID: ");
            int EmployeeId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Password: ");
            string Password = Console.ReadLine();
            EmployeeLoginBL employeeLoginBL = new EmployeeLoginBL();
            bool Login=employeeLoginBL.AdminLogin(EmployeeId,Password).GetAwaiter().GetResult();
            if (Login)
            {
                Console.WriteLine($"User Logged in as {EmployeeId}");
                AdminMenu(EmployeeId);
            }
            Console.WriteLine("Loggin Failed");
            return;
        }
        public static void AdminMenu(int EmployeeId)
        {
            AdminBL adminBL = new AdminBL();
            while (true)
            {
                Console.WriteLine("Admin Menu: ");
                Console.WriteLine("1. Raise Request");
                Console.WriteLine("2. View Request Status (All Requests)");
                Console.WriteLine("3. View Solutions (All Solutions)");
                Console.WriteLine("4.Give Feedback (Only for request raised by them)");
                Console.WriteLine("5. Respond to Solution(Only for request raised by them)");
                Console.WriteLine("6. Provide Solution");
                Console.WriteLine("7.Mark Request as Closed");
                Console.WriteLine("8. View Feedbacks(Only feedbacks given to them)");
                Console.WriteLine("9. Exit");
                int choice=Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        RaiseRequestAdmin(EmployeeId,adminBL);
                        break;
                    case 2:
                        ViewAllRequestAdmin(adminBL);
                        break;
                    case 3:
                        ViewAllSolutionsAdmin(adminBL);
                        break;
                    case 4:
                        GiveFeedback(adminBL, EmployeeId);
                        break;
                    case 5:
                        RespondToSolution(adminBL,EmployeeId);
                        break;
                    case 6:
                        ProvideSolution(adminBL,EmployeeId);
                        break;
                    case 7:
                        MarkRequestClosed(adminBL, EmployeeId);
                        break;
                    case 8:
                        ViewFeedbacks(adminBL, EmployeeId);
                        break;
                    case 9:
                        return;
                    default:
                        break;
                }
            }
        }
        public static void ViewFeedbacks(AdminBL adminBL,int EmployeeId)
        {
            var Feedbacks=adminBL.ViewFeedbacks(EmployeeId).GetAwaiter().GetResult();
            foreach(var f in Feedbacks)
            {
                Console.WriteLine($"FeedBackID: {f.FeedbackId} \n Rating: {f.Rating} \n Remarks: {f.Remarks} \n SolutionID {f.SolutionId} \n FeedbackDate: {f.FeedbackDate} \n");
            }
        }
        public static void MarkRequestClosed(AdminBL adminBL,int EmployeeId)
        {
            Console.WriteLine("Enter Request ID: ");
            int requestID=Convert.ToInt32(Console.ReadLine()) ;
            var res = adminBL.CloseRequest(requestID, EmployeeId).GetAwaiter().GetResult();
            Console.WriteLine("Request Marked as Closed ");
            return;
        }
        public static void ProvideSolution(AdminBL adminBL,int EmployeeId)
        {
            Console.WriteLine("Enter RequestID");
            int requestId=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Solution Description: ");
            string solutionDescription=Console.ReadLine();
            var solutionID=adminBL.ProvideSolution(requestId, solutionDescription,EmployeeId).GetAwaiter().GetResult();
            Console.WriteLine($"Solution Provided with Solution Id: {solutionID}");
        }
        public static void RespondToSolution(AdminBL adminBL,int EmployeeId)
        {
            Console.WriteLine("Enter SolutionID: ");
            int solutionId=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Response: ");
            string response=Console.ReadLine();
            var res= adminBL.RespondToSolution(solutionId, response, EmployeeId).GetAwaiter().GetResult();
            if (res == false)
            {
                Console.WriteLine("Invalid SolutionId");
                return;
            }
            Console.WriteLine("Responded To Solution");
            return;

        }
        public static void GiveFeedback(AdminBL adminBL,int EmployeeId)
        {
            Console.WriteLine("Enter SolutionId: ");
            int SolutionId=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Rating: ");
            float rating=float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Remarks: ");
            string remarks=Console.ReadLine();
            int FeedbackId = adminBL.GiveFeedback(EmployeeId, rating, remarks, SolutionId).GetAwaiter().GetResult();
            if (FeedbackId == -1)
            {
                Console.WriteLine("Invalid Solution Id");
                return;
            }
            Console.WriteLine($"Feedback Given with Id: {FeedbackId}");
            return;
        }
        public static void ViewAllSolutionsAdmin(AdminBL adminBL)
        {
            var Solutions=adminBL.ViewAllSolutions().GetAwaiter().GetResult();
            foreach (var s in Solutions) 
            {
                Console.WriteLine($"Solution Id: {s.SolutionId} \n Request Id: {s.RequestId} \n Solution Description: {s.SolutionDescription} \n Solved By: {s.SolvedBy} \n Solved Date: {s.SolvedDate} \n Is Solved: {s.IsSolved} \n Comment: {s.RequestRaiserComment} \n");            
            }
            return;
        }
        public static void RaiseRequestAdmin(int EmployeeId,AdminBL adminBL)
        {
            Console.WriteLine("Enter RequestMessage: ");
            string RequestMessage = Console.ReadLine();
            int RequestId = adminBL.RaiseRequest(RequestMessage, EmployeeId).GetAwaiter().GetResult();
            Console.WriteLine("Request Raised With Id: " + RequestId);
            return;
        }
        public static void ViewAllRequestAdmin(AdminBL adminBL)
        {
            var Requests = adminBL.ViewRequestStatus().GetAwaiter().GetResult();
            foreach(var r in Requests)
            {
                Console.WriteLine($"Request ID: {r.Item1} Status {r.Item2}");
            }
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
                    case 2:
                        AdminLogin();
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
