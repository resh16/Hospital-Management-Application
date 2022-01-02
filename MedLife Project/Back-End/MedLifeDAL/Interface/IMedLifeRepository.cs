using MedLifeDAL.Entities;
using MedLifeDAL.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedLifeDAL.Interface
{
    public interface IMedLifeRepository
    {

        public void AddDoctorsProfile(AddDoctor addDoctor);
        public void BookAppointment(AppointmentBookingVM appointmentBookingVM);
        //Task<IEnumerable<GetDoctorsVM>> DoctorsList();
        public List<usp_GetAllDoctorsResult> DoctorsList();

        Task<GetDoctorsVM> GetDoctors();
        public List<usp_GetAllPatientsResult> PatientsList();
        public List<usp_GetAllConfirmedPatientsResult> ConformedPatientsList(Guid doctorId);
        public List<usp_PatientDetailsResult> PatientDetails(Guid PatientId);
        public List<usp_GetAllPendingPatientsResult> PendingPatientsList(Guid doctorId);
        public void ModifyStatus(int AppointmentId, Guid PatientId, int StatusId, string Priscription);
        public void ModifyStatus2(ModifyStatus modifyStatus);
    }
}
