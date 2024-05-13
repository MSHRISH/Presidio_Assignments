﻿namespace Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; } 
        public string Role { get; set; } 
        public override string ToString()
        {
            return Id + " " + Name + " " + Role;
        }
        public virtual bool PasswordCheck(string password)
        {
            return this.Password == password;
        }
        public ICollection<Request> RequestsRaised { get; set; }
        public ICollection<Request> RequestsClosed { get; set; }
        public ICollection<Solution> SolutionsGiven { get; set; }
        public ICollection<SolutionFeedback> FeedbacksGiven { get; set; }
    }
}
