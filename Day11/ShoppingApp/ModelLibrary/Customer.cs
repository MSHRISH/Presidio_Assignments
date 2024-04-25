using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    public class Customer
    {
        public int Id { get; set; }
        public string Phone { get; set; } = String.Empty;
        public int Age { get; set; }

        public Customer(int id,string phone,int age) 
        { 
            Id= id;
            Phone= phone;
            Age= age;
        }

    }
}
