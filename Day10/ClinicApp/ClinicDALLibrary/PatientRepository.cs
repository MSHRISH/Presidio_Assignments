using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicModelLibrary;

namespace ClinicDALLibrary
{
    public class PatientRepository:IRepository<int,Patient>
    {
        readonly Dictionary<int, Patient> _Patients;

        public PatientRepository()
        {
            _Patients = new Dictionary<int, Patient>();
        }
        int GenerateId()
        {
            if (_Patients.Count == 0)
                return 1;
            int id = _Patients.Keys.Max();
            return ++id;
        }

        public Patient Add(Patient patient)
        {
            patient.PatientId= GenerateId();
            _Patients.Add(patient.PatientId, patient);
            return patient;
        }

        public Patient Delete(int key)
        {
            if (_Patients.ContainsKey(key))
            {
                var patient= _Patients[key];
                _Patients.Remove(key);
                return patient;
            }
            return null;
        }

        public Patient? Get(int key)
        {
            return _Patients.ContainsKey(key) ? _Patients[key] : null;
        }

        public List<Patient> GetAll()
        {
            if (_Patients.Count == 0)
                return null;
            return _Patients.Values.ToList();
        }

        public Patient Update(Patient patient)
        {
            if (_Patients.ContainsKey(patient.PatientId))
            {
                _Patients[patient.PatientId] = patient;
                return patient;
            }
            return null;
        }

       
    }
}
