using BDAL;
using BEntities.Entities;

namespace BBLL
{
    public class PacientService
    {
        PacientRepository pacientRepository = new PacientRepository();

        public List<Pacient> GetPacientsService()
        {
            return pacientRepository.GetPacientsRepo();
        }
        public string AddPacientService(Pacient pacientFormData)
        {
            return pacientRepository.AddPacient(pacientFormData);
        }

    }
}
