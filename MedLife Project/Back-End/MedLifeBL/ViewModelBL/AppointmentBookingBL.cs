using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedLifeBL.ViewModelBL
{
    public class AppointmentBookingBL
    {
        public int Id { get; set; }
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }
        public DateTime AppointmentOn { get; set; }
        public int HealthProblemId { get; set; }
        public string Others { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }

        public int StatusId { get; set; }
    }
}
