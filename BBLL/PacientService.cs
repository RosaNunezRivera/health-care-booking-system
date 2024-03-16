using BDAL;
using BEntities.Entities;
using System.Net.Http.Headers;

namespace BBLL
{
    public class PacientService
    {
        PacientRepository pacientRepository = new PacientRepository();

        public List<Pacient> GetAllPacientsService()
        {
            return pacientRepository.GetAllPacientsRepo();
        }

        public Pacient GetPacientByIdService(int id)
        {
            return pacientRepository.GetPacientByIdRepo(id);
        }

        public string AddPacientService(Pacient pacientFormData)
        {
            return pacientRepository.AddPacient(pacientFormData);
        }

        public string UpdatePacientService(Pacient pacientFormData) 
        {
            return pacientRepository.UpdatePacientRepo(pacientFormData);
        }

        public string DeletePacientService(int pacId) 
        {
            return pacientRepository.DeletePacientRepo(pacId);
        }
    }
}
