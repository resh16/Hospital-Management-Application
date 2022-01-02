using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedLifeDAL.View_Model
{
   public class AppointmentBookingVM
    {
       // public Guid PatientId { get; set; }
       public int Id { get; set; }
        public Guid DoctorId { get; set; }
        public DateTime AppointmentOn { get; set; }
        public int HealthProblemId { get; set; }
        public string Others { get; set; }
      
       

       // public int StatusId { get; set; }
    }
}
