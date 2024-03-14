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
            var response = pacientService.GetPacientsService();
            return Json(response);
        }

        [HttpPost]
        public IActionResult RegisterPacient([FromBody] Pacient pacientFormData)
        {
            var response = pacientService.AddPacientService(pacientFormData);
            return Json(response);
        }

    }
}
