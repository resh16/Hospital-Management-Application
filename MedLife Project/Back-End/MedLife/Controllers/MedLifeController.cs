using MedLifeBL.Interface;
using MedLifeBL.ViewModelBL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MedLife.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MedLifeController : ControllerBase
    {
        private readonly IMedlifeBL _medlifeBL;
        private readonly IConfiguration _configuration;


        public MedLifeController(IMedlifeBL medlifeBL, IConfiguration configuration)
        {
            this._medlifeBL = medlifeBL;
            this._configuration = configuration;

        }




        [HttpPost]


        public IActionResult AddDoctorsProfile([FromForm] AddDoctorBL addDoctorBL)
        {
            try
            {
                _medlifeBL.AddDoctorsProfile(addDoctorBL);
                return Ok();
            }
            catch (Exception e)
            {
                throw new Exception(e.InnerException.Message);
            }


        }



        [HttpGet]

        public IActionResult ListDoctors()
        {

            try
            {

                var ListOfPatients = _medlifeBL.DoctorsList();

                return Ok(ListOfPatients);

            }


            catch (Exception e)
            {
                throw new Exception(e.InnerException.Message);

            }



        }
        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {
            var image = await _medlifeBL.GetDoctors();




            if (image != null && image.UniqueImageName != null)
            {

                string filePath = Path.Combine(_configuration.GetSection("AppSettings").GetSection("ImagePath").Value.ToString(), image.UniqueImageName);



                if (System.IO.File.Exists(filePath))
                {

                    var bytes = System.IO.File.ReadAllBytes(filePath);
                    return File(bytes, filePath.Contains(".jpg") ? "image/jpg" : "image/pjpg");
                }
            }
            else
            {

                string filePath2 = Path.Combine(_configuration.GetSection("AppSettings").GetSection("ImagePath").Value.ToString(), "DefaultImage.jpg");
                var bytes = System.IO.File.ReadAllBytes(filePath2);
                return File(bytes, "image/jpg");
            }

            return null;
        }


        [HttpGet]

        public  IActionResult ListPatients()
        {

            try
            {

                var ListOfPatients = _medlifeBL.PatientsList();

                return Ok(ListOfPatients);

            }


            catch (Exception e)
            {
                throw new Exception(e.InnerException.Message);

            }



        }


        [HttpGet]

        public IActionResult ListConformedPatients(Guid doctorId)
        {

            try
            {

                var ListOfConformedPatients = _medlifeBL.ConformedPatientsList(doctorId);

                return Ok(ListOfConformedPatients);

            }


            catch (Exception e)
            {
                throw new Exception(e.InnerException.Message);

            }



        }


        [HttpGet]

        public IActionResult ListPendingPatients(Guid doctorId)
        {

            try
            {

                var ListOfPendingPatients = _medlifeBL.PendingPatientsList(doctorId);

                return Ok(ListOfPendingPatients);

            }


            catch (Exception e)
            {
                throw new Exception(e.InnerException.Message);

            }



        }

        [HttpGet]

        public IActionResult PatientDetails(Guid patientId)
        {

            try
            {

                var Patients = _medlifeBL.GetPatientDetails(patientId);

                return Ok(Patients);

            }


            catch (Exception e)
            {
                throw new Exception(e.InnerException.Message);

            }



        }


        [HttpPost]


        public IActionResult ModifyStatus(int AppointmentId, Guid PatientId,int StatusId,string Priscription)
        {
            try
            {
                _medlifeBL.ModifyStatus( AppointmentId,PatientId, StatusId, Priscription);
                return Ok();
            }
            catch (Exception e)
            {
                throw new Exception(e.InnerException.Message);
            }


        }

        [HttpPost]

        public IActionResult ModifyStatus2([FromForm]ModifyStatusBL modifyStatusBL)
        {
            try
            {
                _medlifeBL.ModifyStatus2(modifyStatusBL);
                return Ok();
            }
            catch (Exception e)
            {
                throw new Exception(e.InnerException.Message);
            }


        }





        [HttpPost]
        

        public IActionResult BookAppointment(AppointmentBookingBL appointmentBookingBL)
        {
            try
            {
                _medlifeBL.BookAppointment(appointmentBookingBL);
                return Ok();
            }
            catch (Exception e)
            {
                throw new Exception(e.InnerException.Message);
            }


        }
    }
}



