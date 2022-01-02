using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedLifeDAL.View_Model
{
    public class ModifyStatus
    {
        public int AppointmentId { get; set; }
        public Guid PatientId { get; set; }
        
        public string Priscription { get; set; }
        public int StatusId { get; set; }
    }
}
