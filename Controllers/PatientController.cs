using Azure;
using BBLL;
using BEntities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PatientBookingWebApplication.Controllers
{
    public class PatientController : Controller
    {
        PatientService patientService = new PatientService();
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetPatients()
        {
            var response = patientService.GetAllPatientsService();
            return Json(response);
        }

        [HttpPost]
        public IActionResult RegisterPatient([FromBody] Patient patientFormData)
        {
            var response = patientService.AddPatientService(patientFormData);
            return Json(response);
        }

        [HttpGet]
        public IActionResult GetPatientById(int id)
        {
            var pacById = patientService.GetPatientByIdService(id);

            return Json(pacById);
        }

        [HttpPost]
        public IActionResult UpdatePatient([FromBody] Patient patientFormData)
        {
            var patientToUpdated = patientService.UpdatePatientService(patientFormData);
            return Json(patientToUpdated);
        }

        [HttpPost]
        public IActionResult DeletePatient([FromBody] int patID)
        {
            try
            {
                var response = patientService.DeletePatientService(patID);
                return Json(response);
            }
            catch (Exception ex)
            {
                return Json("error");
            }
        }
    }
}
