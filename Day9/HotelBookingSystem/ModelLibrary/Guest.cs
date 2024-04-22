using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    public class Guest
    {
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber {  get; set; }=string.Empty;

        public List<Reservation> Reservations { get; set; }=new List<Reservation>();


        public Guest(string name,string phonenumber)
        {
            Name = name;
            PhoneNumber = phonenumber;
        }
    }
}
