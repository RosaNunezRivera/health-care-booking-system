using Azure;
using BBLL;
using BEntities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PatientBookingWebApplication.Controllers
{
    public class PacientController : Controller
    {
        PacientService pacientService = new PacientService();
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetPacients()
        {
            var response = pacientService.GetAllPacientsService();
            return Json(response);
        }

        [HttpPost]
        public IActionResult RegisterPacient([FromBody] Pacient pacientFormData)
        {
            var response = pacientService.AddPacientService(pacientFormData);
            return Json(response);
        }

        [HttpGet]
        public IActionResult GetPacientById(int id)
        {
            var pacById = pacientService.GetPacientByIdService(id);

            return Json(pacById);
        }

        [HttpPost]
        public IActionResult UpdatePacient([FromBody] Pacient pacientFormData)
        {
            var pacientToUpdated = pacientService.UpdatePacientService(pacientFormData);
            return Json(pacientToUpdated);
        }

        [HttpPost]
        public IActionResult DeletePacient([FromBody] int pacId)
        {
            try
            {
                var response = pacientService.DeletePacientService(pacId);
                return Json(response);
            }
            catch (Exception ex)
            {
                return Json("error");
            }
        }
    }
}
