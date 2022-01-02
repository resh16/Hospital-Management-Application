using MedLifeBL.Interface;
using MedLifeBL.ViewModelBL;
using MedLifeDAL.Entities;
using MedLifeDAL.Interface;
using MedLifeDAL.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedLifeBL.Logics
{
   public class MedlifeBL:IMedlifeBL
    {
        private readonly IMedLifeRepository _medLifeRepositoryDAL;

        public MedlifeBL(IMedLifeRepository medLifeRepository)
        {
            this._medLifeRepositoryDAL = medLifeRepository;
        }


        public void AddDoctorsProfile(AddDoctorBL addDoctorBL)
        {
            AddDoctor addDoctor = new AddDoctor();

            addDoctor.Id = addDoctorBL.Id;
            addDoctor.Qualification = addDoctorBL.Qualification;
            addDoctor.Experience = addDoctorBL.Experience;
            addDoctor.Image = addDoctorBL.Image;
            
            addDoctor.DepartmentId = addDoctorBL.DepartmentId;
           

            _medLifeRepositoryDAL.AddDoctorsProfile(addDoctor);

        }

        //public async Task<IEnumerable<GetDoctorsVM>> DoctorsList()
        //{
        //   return await _medLifeRepositoryDAL.DoctorsList();
        //}

        public List<usp_GetAllDoctorsResult> DoctorsList()

        {

            var doctorsList = _medLifeRepositoryDAL.DoctorsList();
            return doctorsList;
        }


        public async Task<GetDoctorsVM> GetDoctors()
        {

            var res = await _medLifeRepositoryDAL.GetDoctors();

            return res;

        }


        public List<usp_GetAllConfirmedPatientsResult> ConformedPatientsList(Guid doctorId)

        {

            var conformedPatientsList = _medLifeRepositoryDAL.ConformedPatientsList(doctorId);
            return conformedPatientsList;
        }







        public List<usp_GetAllPendingPatientsResult> PendingPatientsList(Guid doctorId)
        {

            var pendingPatientsList = _medLifeRepositoryDAL.PendingPatientsList(doctorId);
            return pendingPatientsList;
        }


        public List<usp_GetAllPatientsResult> PatientsList()
        {
            var patientsList = _medLifeRepositoryDAL.PatientsList();
            return patientsList;
        }


        public List<usp_PatientDetailsResult> GetPatientDetails(Guid PatientId)
        {

            var patientDetails = _medLifeRepositoryDAL.PatientDetails(PatientId);
            return patientDetails;
        }



        public void ModifyStatus(int AppointmentId, Guid PatientId, int StatusId, string Priscription)
        {
            _medLifeRepositoryDAL.ModifyStatus( AppointmentId, PatientId, StatusId, Priscription);

        }

        public void ModifyStatus2(ModifyStatusBL modifyStatusBL)
        {
            ModifyStatus modifyStatus = new ModifyStatus();

            modifyStatus.AppointmentId = modifyStatusBL.AppointmentId;
            modifyStatus.StatusId = modifyStatusBL.StatusId;
            modifyStatus.Priscription = modifyStatusBL.Priscription;

            _medLifeRepositoryDAL.ModifyStatus2(modifyStatus);

        }




        public void BookAppointment(AppointmentBookingBL appointmentBookingBL)
        {
            AppointmentBookingVM appointmentBookingVM = new AppointmentBookingVM();


          //  appointmentBookingVM.PatientId = appointmentBookingBL.PatientId;
            appointmentBookingVM.DoctorId = appointmentBookingBL.DoctorId;
            appointmentBookingVM.AppointmentOn = appointmentBookingBL.AppointmentOn;
            appointmentBookingVM.HealthProblemId = appointmentBookingBL.HealthProblemId;
          //  appointmentBookingVM.StatusId = appointmentBookingBL.StatusId;
            appointmentBookingVM.Others = appointmentBookingBL.Others;
         //   appointmentBookingVM.CreatedBy = appointmentBookingBL.CreatedBy;
            


            _medLifeRepositoryDAL.BookAppointment(appointmentBookingVM);
        }


    }
}
