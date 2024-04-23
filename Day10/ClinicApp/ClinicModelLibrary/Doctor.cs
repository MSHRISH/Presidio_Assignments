using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicModelLibrary
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set;}=string.Empty;
        
        DateTime dob;
        int age;
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

        public int ServiceYears { get; set; }

        public Doctor()
        {
            DoctorId = 0;
            DoctorName = string.Empty;
            DateOfBirth = DateTime.Today;
            ServiceYears = 0;
        }

        public Doctor(int docid,string docname,DateTime dob,int serviceyears)
        {
            DoctorId=docid;
            DoctorName=docname;
            DateOfBirth = dob;
            ServiceYears = serviceyears;
        }
        public Doctor(string doctorname)
        {
            DoctorName=doctorname;
        }

    }
}
