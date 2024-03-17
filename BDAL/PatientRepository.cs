using BEntities.Context;
using BEntities.Entities;
using System.Net.Http.Headers;

namespace BDAL
{
    public class PatientRepository
    {
        PatientBookingContext patientBookingContext = new PatientBookingContext();

        public List<Patient> GetAllPatientsRepo()
        {
            return patientBookingContext.Patients.ToList();
        }

        public string AddPatient(Patient patientFormData)
        {
            if (patientFormData != null)
            {
                patientBookingContext.Patients.Add(patientFormData);
                patientBookingContext.SaveChanges();
                return "success";
            }
            return "error";
        }
        public Patient GetPatientByIdRepo(int id)
        {
            return patientBookingContext.Patients.FirstOrDefault(x => x.PatientID == id);
        }

        public string UpdatePatientRepo(Patient patientFormData)
        {
            Patient pacToBeUpdated = patientBookingContext.Patients.FirstOrDefault(x => x.PatientID == patientFormData.PatientID);

            if (pacToBeUpdated != null)
            {
                pacToBeUpdated.PatientName = patientFormData.PatientName;
                pacToBeUpdated.Email = patientFormData.Email;
                pacToBeUpdated.PhoneNumber = patientFormData.PhoneNumber;
                pacToBeUpdated.DOB = patientFormData.DOB;

                //Mapper.Map(pac, pacToBeUpdated); Using automapper is only one line
                patientBookingContext.SaveChanges();
                return "success";
            }
            return "error";
        }

        public string DeletePatientRepo(int patID) 
        {
            var response = "";
            try 
            {
                Patient pacToBeDeleted = patientBookingContext.Patients.FirstOrDefault(x => x.PatientID == patID);
                if (pacToBeDeleted != null)
                {
                    patientBookingContext.Patients.Remove(pacToBeDeleted);
                    patientBookingContext.SaveChanges();
                    response = "success";
                }
                else 
                {
                    response = "error: Patient not found";
                }
            }
            catch (Exception ex) 
            {
                response = $"error: {ex.Message}";
            }
            return response;
        }
    }
}
