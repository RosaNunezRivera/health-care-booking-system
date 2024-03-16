using BEntities.Context;
using BEntities.Entities;
using System.Net.Http.Headers;

namespace BDAL
{
    public class PacientRepository
    {
        PacientBookingContext pacientBookingContext = new PacientBookingContext();

        public List<Pacient> GetAllPacientsRepo()
        {
            return pacientBookingContext.Pacients.ToList();
        }

        public string AddPacient(Pacient pacientFormData)
        {
            if (pacientFormData != null)
            {
                pacientBookingContext.Pacients.Add(pacientFormData);
                pacientBookingContext.SaveChanges();
                return "success";
            }
            return "error";
        }
        public Pacient GetPacientByIdRepo(int id)
        {
            return pacientBookingContext.Pacients.FirstOrDefault(x => x.PacientID == id);
        }

        public string UpdatePacientRepo(Pacient pacientFormData)
        {
            Pacient pacToBeUpdated = pacientBookingContext.Pacients.FirstOrDefault(x => x.PacientID == pacientFormData.PacientID);

            if (pacToBeUpdated != null)
            {
                pacToBeUpdated.PacientName = pacientFormData.PacientName;
                pacToBeUpdated.Email = pacientFormData.Email;
                pacToBeUpdated.PhoneNumber = pacientFormData.PhoneNumber;
                pacToBeUpdated.DOB = pacientFormData.DOB;

                //Mapper.Map(pac, pacToBeUpdated); Using automapper is only one line
                pacientBookingContext.SaveChanges();
                return "success";
            }
            return "error";
        }

        public string DeletePacientRepo(int pacId) 
        {
            var response = "";
            try 
            {
                Pacient pacToBeDeleted = pacientBookingContext.Pacients.FirstOrDefault(x => x.PacientID == pacId);
                if (pacToBeDeleted != null)
                {
                    pacientBookingContext.Pacients.Remove(pacToBeDeleted);
                    pacientBookingContext.SaveChanges();
                    response = "success";
                }
                else 
                {
                    response = "error: Pacient not found";
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
