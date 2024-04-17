using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicModelLibrary
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }=string.Empty;
        public string Gender {  get; set; }=string.Empty;
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

        public Patient()
        {
            PatientId = 0;
            PatientName = string.Empty;
            Gender = string.Empty;
            DateOfBirth = DateTime.Today;
        }

        public Patient(int patientid, string patientname,string gender,DateTime dob)
        {
            PatientId=patientid;
            PatientName = patientname;
            Gender = gender;
            DateOfBirth = dob;
        }

    }
}
