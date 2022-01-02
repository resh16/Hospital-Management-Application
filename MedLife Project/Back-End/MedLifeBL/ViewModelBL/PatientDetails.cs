using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedLifeBL.ViewModelBL
{
    public class PatientDetails
    {
        public Guid PatientId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public DateTime AppointmentOn { get; set; }
        public string HealthProblem { get; set; }
        public string others { get; set; }
        public string Status { get; set; }
        public string Priscription { get; set; }

    }
}
