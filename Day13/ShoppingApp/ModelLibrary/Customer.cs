using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    public class Customer : IEquatable<Customer>,IComparable<Customer>
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string Phone { get; set; } = String.Empty;
        public int Age { get; set; }

        public Customer(int id,string name,int age) 
        {
            Id = id;
            Name = name;
            Age= age;
        }

        public int CompareTo(Customer? other)
        {
            if (this.Age == other.Age)
                return 0;
            else if (this.Age < other.Age)
                return -1;
            else
                return 1;
            //return this.Age.CompareTo(other.Age);
        }

        public bool Equals(Customer? other)
        {
            return this.Id.Equals(other.Id);
        }

    }
}
