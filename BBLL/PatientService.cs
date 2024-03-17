using BDAL;
using BEntities.Entities;
using System.Net.Http.Headers;

namespace BBLL
{
    public class PatientService
    {
        PatientRepository patientRepository = new PatientRepository();

        public List<Patient> GetAllPatientsService()
        {
            return patientRepository.GetAllPatientsRepo();
        }

        public Patient GetPatientByIdService(int id)
        {
            return patientRepository.GetPatientByIdRepo(id);
        }

        public string AddPatientService(Patient patientFormData)
        {
            return patientRepository.AddPatient(patientFormData);
        }

        public string UpdatePatientService(Patient patientFormData) 
        {
            return patientRepository.UpdatePatientRepo(patientFormData);
        }

        public string DeletePatientService(int patID) 
        {
            return patientRepository.DeletePatientRepo(patID);
        }
    }
}
