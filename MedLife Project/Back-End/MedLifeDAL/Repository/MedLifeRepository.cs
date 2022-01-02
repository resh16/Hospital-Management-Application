
using Dapper;
using MedLifeDAL.Data;
using MedLifeDAL.Entities;
using MedLifeDAL.Interface;
using MedLifeDAL.View_Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MedLifeDAL.Repository
{
    public class MedLifeRepository:IMedLifeRepository
    {
        private readonly IConfiguration _configuration;
        private readonly MedlifeContext _context;
        private UserManager<AppUser> _userManager;



        public MedLifeRepository(IConfiguration configuration, MedlifeContext context)
        {
            this._configuration = configuration;
            this._context = context;
        }


        //Add Doctors profile - admin

        public void AddDoctorsProfile(AddDoctor addDoctor)
        {
            Doctors doctors = new Doctors();

           


            FileInfo fi = new(addDoctor.Image.FileName);

            var Filename = $"{DateTime.UtcNow.ToString("yyyyMMddTHHmmssfffffffK")}{fi.Extension}";

            //Store to filePath
            string filePath = Path.Combine(_configuration.GetSection("AppSettings:ImagePath").Value.ToString(), Filename);


            if (addDoctor.Image != null)
            {



                using (var fs = File.Create(filePath))
                {
                    addDoctor.Image.CopyTo(fs);
                }

            }

            // appUser.DoctorsIdNavigation = new Doctors();
            doctors.Id = addDoctor.Id;
            doctors.DepartmentId = addDoctor.DepartmentId;
            doctors.Qualification = addDoctor.Qualification;
            doctors.Experience = addDoctor.Experience;
            doctors.Image = addDoctor.Image.FileName;
            doctors.UniqueImageName = Filename;
            doctors.CreatedAt = DateTime.UtcNow;
            doctors.CreatedBy = Guid.Parse("374D7318-6E5B-45D7-9992-D6C0CF3AB93A");





            _context.Doctors.Add(doctors);
            _context.SaveChanges();


        }


        public async Task<GetDoctorsVM> GetDoctors()
        {
            using IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            string sp = "usp_GetAllDoctors";

            return await Task.FromResult(dbConnection.Query<GetDoctorsVM>(sp,commandType: CommandType.StoredProcedure).FirstOrDefault());

        }


        //Doctors List
        public  List<usp_GetAllDoctorsResult> DoctorsList()
        {
            

            var doctorList = _context.Procedures.usp_GetAllDoctorsAsync().Result.ToList();
            return doctorList;
        }


        
        //// patient List
        public List<usp_GetAllPatientsResult> PatientsList()
        {
            var patientsList = _context.Procedures.usp_GetAllPatientsAsync().Result.ToList();
            return patientsList;
        }


        //Get all conformed patients
        public List<usp_GetAllConfirmedPatientsResult> ConformedPatientsList(Guid doctorId)

        {
            Guid Id = Guid.Parse("A9B74184-9FB6-4841-A5A1-08D9C763981E");
            var conformedPatientsList = _context.Procedures.usp_GetAllConfirmedPatientsAsync(Id).Result.ToList();
            return conformedPatientsList;
        }


        //Get all Pending patients
        public List<usp_GetAllPendingPatientsResult> PendingPatientsList(Guid doctorId)
        {
            Guid Id = Guid.Parse("A9B74184-9FB6-4841-A5A1-08D9C763981E");
            var pendingPatientsList = _context.Procedures.usp_GetAllPendingPatientsAsync(Id).Result.ToList();
            return pendingPatientsList;
        }

        //Get patient details

        public List<usp_PatientDetailsResult> PatientDetails(Guid PatientId)
        {
            Guid Id = Guid.Parse("9C5B19C5-4518-482D-E80A-08D9C6BDF874"); 
         var patientDetails = _context.Procedures.usp_PatientDetailsAsync(Id).Result.ToList();
            return patientDetails;
        }
        



        // Booking Appointment by patient

        public void BookAppointment(AppointmentBookingVM appointmentBookingVM)
        {
            AppoinmentBooking appoinmentBooking = new AppoinmentBooking();

            appoinmentBooking.PatientId = Guid.Parse("9C5B19C5-4518-482D-E80A-08D9C6BDF874"); 
            appoinmentBooking.DoctorId = appointmentBookingVM.DoctorId;
            appoinmentBooking.AppointmentOn = appointmentBookingVM.AppointmentOn;
            appoinmentBooking.HealthProblemId = appointmentBookingVM.HealthProblemId;
            appoinmentBooking.Others = appointmentBookingVM.Others;
            appoinmentBooking.StatusId = 1;
            appoinmentBooking.CreatedBy = Guid.Parse("9C5B19C5-4518-482D-E80A-08D9C6BDF874");
            appoinmentBooking.CreatedAt = DateTime.UtcNow;

            _context.AppoinmentBooking.Add(appoinmentBooking);
            _context.SaveChanges();
        }


        public void ModifyStatus(int AppointmentId, Guid PatientId,int StatusId,string Priscription)
        {
            using IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            Guid Id = Guid.Parse("9C5B19C5-4518-482D-E80A-08D9C6BDF874");
            string sp = "usp_ModifyStatus";

                DynamicParameters parameter = new();
            
                parameter.Add("PatientId", Id);
                parameter.Add("AppointmentId", AppointmentId);
                parameter.Add("StatusId", StatusId);
                parameter.Add("Priscription", Priscription);

            SqlMapper.Execute(dbConnection, sp, commandType: CommandType.StoredProcedure, param: parameter);

        }

        public void ModifyStatus2(ModifyStatus modifyStatus)
        {
            using IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            Guid Id = Guid.Parse("9C5B19C5-4518-482D-E80A-08D9C6BDF874");
            string sp = "usp_ModifyStatus";

            DynamicParameters parameter = new();

            parameter.Add("PatientId", Id);
            parameter.Add("AppointmentId", modifyStatus.AppointmentId);
            parameter.Add("StatusId", modifyStatus.StatusId);
            parameter.Add("Priscription", modifyStatus.Priscription);

            SqlMapper.Execute(dbConnection, sp, commandType: CommandType.StoredProcedure, param: parameter);

        }





    }
}

//public void UpdateAuthor(int id, Author author)
//{
//    using IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

//    string sp = "Sp_UpdateAuthor";

//    DynamicParameters parameter = new();

//    parameter.Add("id", id);
//    parameter.Add("Name", author.Name);

//    SqlMapper.Execute(dbConnection, sp, commandType: CommandType.StoredProcedure, param: parameter);
//}