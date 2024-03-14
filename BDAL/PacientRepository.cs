using BEntities.Context;
using BEntities.Entities;

namespace BDAL
{
    public class PacientRepository
    {
        PacientBookingContext pacientBookingContext = new PacientBookingContext();

        public List<Pacient> GetPacientsRepo()
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
    }
}
